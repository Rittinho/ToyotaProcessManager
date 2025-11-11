using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Contract;
public interface IJsonServices
{
    void SaveJson<T>(string path, string jsonName, T data);

    List<ToyotaEmployee> LoadEmployeeJson(string path, string jsonName);
    List<ToyotaProcess> LoadProcessJson(string path, string jsonName);
    List<ToyotaTableGroup> LoadTableGroupJson(string path, string jsonName);
}
