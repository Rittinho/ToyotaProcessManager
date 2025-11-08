using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.DTOs;
public record ToyotaProcessDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IconParametersDTO Icon { get; set; }
}