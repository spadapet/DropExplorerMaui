using Microsoft.Maui.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using VsDrops.Model;
using VsDrops.Utility;

namespace VsDrops.UI;

internal partial class MainPage : ContentPage, IUpdatable
{
    public ShellModel Model { get; }
    private CancellationTokenSource cancellationTokenSource;

    public MainPage()
    {
        this.Model = new ShellModel(App.Current.Model);
        this.InitializeComponent();
    }

    private void OnLoaded(object sender, EventArgs args)
    {
        this.StartUpdate();
    }

    public void StartUpdate()
    {
        if (this.cancellationTokenSource != null)
        {
            // Already updating
            return;
        }

        TaskUtility.FileAndForget(async () =>
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            WorkData work = new("Getting Azure DevOps data", this.cancellationTokenSource)
            {
                Progress = 1
            };

            using (this.Model.AppModel.ProgressBar.Begin(work))
            {
                try
                {
                    await this.UpdateAsync(this.cancellationTokenSource.Token);
                }
                catch (Exception ex)
                {
                    this.Model.AppModel.InfoBar.SetError(ex);
                    throw;
                }
                finally
                {
                    this.cancellationTokenSource = null;
                }
            }
        });
    }

    private async Task UpdateAsync(CancellationToken cancellationToken)
    {
        AdoModel ado = this.Model.AppModel.AdoModel;

        await AdoUtility.UpdateAccountsAsync(ado, cancellationToken);

        if (ado.CurrentAccount is AdoAccount account)
        {
            await AdoUtility.UpdateProjectsAsync(ado.Connection, account, cancellationToken);
        }
    }

    private void OnClickCancel(object sender, EventArgs args)
    {
        this.cancellationTokenSource?.Cancel();
    }
}
