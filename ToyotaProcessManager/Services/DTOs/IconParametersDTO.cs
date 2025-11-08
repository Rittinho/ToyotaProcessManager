using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyotaProcessManager.Services.DTOs;
public record IconParametersDTO
{
    public string Unicode { get; set; }
    public string ColorCode { get; set; }
}
