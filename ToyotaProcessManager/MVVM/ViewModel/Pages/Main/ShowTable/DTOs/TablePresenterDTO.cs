using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.ViewModel.Pages.Main.ShowTable.DTOs;
public record TablePresenterDTO(ToyotaProcess process, ObservableCollection<ToyotaEmployee> employees)
{
    public ToyotaProcess Process { get; set; } = process;
    public ObservableCollection<ToyotaEmployee> Employees { get; set; } = employees;

}
