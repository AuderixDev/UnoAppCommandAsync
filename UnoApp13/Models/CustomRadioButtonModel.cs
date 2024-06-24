using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UnoApp13.Models;
public partial class CustomRadioButtonModel : ObservableObject
{
    public string ButtonText { get; set; }

    public ICommand ButtonCommand { get; set; }
    private bool _customRadioButtonIsEnabled = false;
    public bool CustomRadioButtonIsEnabled { get => _customRadioButtonIsEnabled; set => SetProperty(ref _customRadioButtonIsEnabled, value); }

}
