using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.MVVM.Model.Domain.Employee.DTOs;
public class ToyotaEmployeeDTO
{
    public DateTime CreationDate { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
}
