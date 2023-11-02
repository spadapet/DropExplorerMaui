namespace VsDrops.Model;

public sealed class MainModel(AppModel appModel) : PropertyNotifier
{
    public AppModel AppModel { get; } = appModel;

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
        get => this.AppModel.AdoModel.CurrentAccount?.CurrentProject?.BuildDefinitions.IndexOf(this.BuildDefinition) ?? -1;
        set
        {
            if (this.AppModel.AdoModel.CurrentAccount?.CurrentProject is AdoProject project &&
                value != this.BuildDefinitionIndex &&
                value >= 0 &&
                value < project.BuildDefinitions.Count)
            {
                this.buildDefinition = project.BuildDefinitions[value];
                this.OnPropertyChanged(nameof(this.BuildDefinition));
            }
        }
    }
}
