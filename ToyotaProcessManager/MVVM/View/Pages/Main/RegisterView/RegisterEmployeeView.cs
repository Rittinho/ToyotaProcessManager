using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToyotaProcessManager.MVVM.View.Pages.Main.RegisterView;
public partial class RegisterView
{
    public ICommand EditEmployeeOnCommand => new Command(EditEmployeeOn);
    public ICommand EditEmployeeOffCommand => new Command(EditEployeeOff);

    public void EditEmployeeOn()
    {
        EmployeeEditButtons.IsVisible = true;
        EmployeeCreateButtons.IsVisible = false;
    }
    public void EditEployeeOff()
    {
        EmployeeEditButtons.IsVisible = false;
        EmployeeCreateButtons.IsVisible = true;
    }
}
