using CommunityToolkit.Mvvm.Input;

namespace UnoApp13.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";


        var btn1 = new CustomRadioButtonModel()
        { ButtonText = "Custom Button 1", CustomRadioButtonIsEnabled = true };


        var btn2 = new CustomRadioButtonModel()
        { ButtonText = "Custom Button 2", CustomRadioButtonIsEnabled = false };
        

        var cmd = Command.Async(async (ct) =>
        {
            btn2.CustomRadioButtonIsEnabled = !btn2.CustomRadioButtonIsEnabled;
            await Task.Delay(100);
        });
        btn1.ButtonCommand = cmd;

        CustomRadioButtons.AddAsync(btn1, CancellationToken.None);
        CustomRadioButtons.AddAsync(btn2, CancellationToken.None);
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

    public IListState<CustomRadioButtonModel> CustomRadioButtons => ListState<CustomRadioButtonModel>.Empty(this);

}
