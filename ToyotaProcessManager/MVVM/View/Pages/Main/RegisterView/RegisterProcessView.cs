using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;
public partial class RegisterView
{
    public ICommand EditProcessOnCommand => new Command(EditProcessOn);
    public ICommand EditProcessOffCommand => new Command(EditProcessOff);

    public void EditProcessOn()
    {
        ProcessEditButtons.IsVisible = true;
        ProcessCreateButtons.IsVisible = false;
    }
    public void EditProcessOff()
    {
        ProcessEditButtons.IsVisible = false;
        ProcessCreateButtons.IsVisible = true;
    }
}
