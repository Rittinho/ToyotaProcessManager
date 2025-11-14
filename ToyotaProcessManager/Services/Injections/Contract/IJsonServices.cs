using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Contract;
public interface IJsonServices
{
    void SaveEmployeeJson(List<ToyotaEmployee> data);
    void SaveProcessJson(List<ToyotaProcess> data);
    void SaveTableGroupJson(List<ToyotaTableGroup> data);

    List<ToyotaEmployee> LoadEmployeeJson();
    List<ToyotaProcess> LoadProcessJson();
    List<ToyotaTableGroup> LoadTableGroupJson();
}
