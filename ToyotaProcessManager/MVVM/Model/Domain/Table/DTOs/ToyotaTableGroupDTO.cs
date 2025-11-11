using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.MVVM.Model.Domain.Table.DTOs;
public record class ToyotaTableGroupDTO
{
    public List<ToyotaTableDTO> TableGroup { get; set; }
}
