using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Process.DTOs;
public record ToyotaProcessDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IconParametersDTO Icon { get; set; }
}