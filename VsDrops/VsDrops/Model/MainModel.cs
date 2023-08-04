namespace VsDrops.Model;

public sealed class MainModel : PropertyNotifier
{
    public AppModel AppModel { get; }

    public MainModel(AppModel appModel)
    {
        this.AppModel = appModel;
    }

    private AdoBuildDefinition buildDefinition;
    public AdoBuildDefinition BuildDefinition
    {
        get => this.buildDefinition;
        set
        {
            if (this.SetProperty(ref this.buildDefinition, value))
            {
                this.OnPropertyChanged(nameof(this.BuildDefinitionIndex));
            }
        }
    }

    public int BuildDefinitionIndex
    {
        get => this.AppModel.AdoModel.CurrentAccount.CurrentProject.BuildDefinitions.IndexOf(this.BuildDefinition);
        set
        {
            if (value != this.BuildDefinitionIndex &&
                value >= 0 &&
                value < this.AppModel.AdoModel.CurrentAccount.CurrentProject.BuildDefinitions.Count)
            {
                this.buildDefinition = this.AppModel.AdoModel.CurrentAccount.CurrentProject.BuildDefinitions[value];
                this.OnPropertyChanged(nameof(this.BuildDefinition));
            }
        }
    }
}
