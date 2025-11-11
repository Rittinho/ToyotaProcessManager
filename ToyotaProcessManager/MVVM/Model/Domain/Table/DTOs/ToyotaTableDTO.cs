using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.MVVM.Model.Domain.Employee.DTOs;
using ToyotaProcessManager.MVVM.Model.Domain.Process.DTOs;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Table.DTOs;
public record ToyotaTableDTO
{
    public ToyotaProcessDTO Process { get; set; }
    public ObservableCollection<ToyotaEmployeeDTO> Employees { get; set; }
}