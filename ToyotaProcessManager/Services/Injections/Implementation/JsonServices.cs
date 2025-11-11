using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using ToyotaProcessManager.MVVM.Model.Domain.Employee.DTOs;
using ToyotaProcessManager.MVVM.Model.Domain.Process.DTOs;
using ToyotaProcessManager.MVVM.Model.Domain.Table.DTOs;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation;
public class JsonServices : IJsonServices
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public void SaveJson<T>(string path, string jsonName,T data)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var jsonPath = Path.Combine(path, $"{jsonName}.json");

        if (File.Exists(jsonPath))
            File.Create(jsonPath).Dispose();

        using (StreamWriter streamWriter = new StreamWriter(jsonPath, false, Encoding.UTF8))
        {
            var json = JsonSerializer.Serialize(data,options);
            streamWriter.Write(json);
        }
    }

    public List<ToyotaEmployee> LoadEmployeeJson(string path, string jsonName)
    {
        var jsonPath = Path.Combine(path, $"{jsonName}.json");

        if (!File.Exists(jsonPath))
            return null;

        List<ToyotaEmployeeDTO> result = null;

        using (StreamReader stream = new(jsonPath))
        {
            string json = stream.ReadToEnd();
            try
            {
                result = JsonSerializer.Deserialize<List<ToyotaEmployeeDTO>>(json, options);
            }
            catch
            {
                return null;
            }
        }

        List<ToyotaEmployee> employeeList = [];

        foreach (var employee in result)
        {
            employeeList.Add(new(employee.Name, employee.Position));
        }

        return employeeList;
    }
    public List<ToyotaProcess> LoadProcessJson(string path, string jsonName)
    {
        var jsonPath = Path.Combine(path, $"{jsonName}.json");

        if (!File.Exists(jsonPath))
            return null;

        List<ToyotaProcessDTO> result = null;

        using (StreamReader stream = new(jsonPath))
        {
            string json = stream.ReadToEnd();
            try
            {
                result = JsonSerializer.Deserialize<List<ToyotaProcessDTO>>(json, options);
            }
            catch
            {
                return null;
            }
        }

        List<ToyotaProcess> processList = [];

        foreach (var process in result)
        {
            processList.Add(new (new(process.Icon.Unicode, process.Icon.ColorCode), process.Title,process.Description));
        }

        return processList;
    }

    public List<ToyotaTableGroup> LoadTableGroupJson(string path, string jsonName)
    {
        var jsonPath = Path.Combine(path, $"{jsonName}.json");

        if (!File.Exists(jsonPath))
            return null;

        List<ToyotaTableGroupDTO> result = null;

        using (StreamReader stream = new(jsonPath))
        {
            string json = stream.ReadToEnd();
            try
            {
                result = JsonSerializer.Deserialize<List<ToyotaTableGroupDTO>>(json, options);
            }
            catch
            {
                return null;
            }
        }

        List<ToyotaTableGroup> tableGroupList = [];

        foreach (var tableGroups in result)
        {
            ToyotaTableGroup group = new([]);
            foreach (var tableGroup in tableGroups.TableGroup)
            {
                ToyotaProcess process = new(new(tableGroup.Process.Icon.Unicode, 
                    tableGroup.Process.Icon.ColorCode), tableGroup.Process.Title, 
                    tableGroup.Process.Description);

                List<ToyotaEmployee> employees = [];

                foreach (var employee in tableGroup.Employees)
                {
                    employees.Add(new(employee.Name, employee.Position));
                }
                ToyotaTable table = new(process, employees);
                group.TableGroup.Add(table);
            }
            tableGroupList.Add(group);
        }

        return tableGroupList;
    }
}
