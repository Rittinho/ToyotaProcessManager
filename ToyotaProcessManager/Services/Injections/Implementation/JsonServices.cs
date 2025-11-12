using System.Text;using System.Text.Encodings.Web;using System.Text.Json;
using ToyotaProcessManager.Services.Injections.Contract;
using ToyotaProcessManager.Services.ValueObjects;

namespace ToyotaProcessManager.Services.Injections.Implementation;
public class JsonServices : IJsonServices
{
    JsonSerializerOptions options = new ()
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

        List<ToyotaEmployee> result = null;

        using (StreamReader stream = new(jsonPath))
        {
            string json = stream.ReadToEnd();
            try
            {
                result = JsonSerializer.Deserialize<List<ToyotaEmployee>>(json, options);
            }
            catch
            {
                return null;
            }
        }

        return result;
    }
    public List<ToyotaProcess> LoadProcessJson(string path, string jsonName)
    {
        var jsonPath = Path.Combine(path, $"{jsonName}.json");

        if (!File.Exists(jsonPath))
            return null;

        List<ToyotaProcess> result = [];

        using (StreamReader stream = new(jsonPath))
        {
            string json = stream.ReadToEnd();
            try
            {
                result = JsonSerializer.Deserialize<List<ToyotaProcess>>(json, options);
            }
            catch
            {
                return [];
            }
        }

        return result;
    }
    public List<ToyotaTableGroup> LoadTableGroupJson(string path, string jsonName)
    {
        var jsonPath = Path.Combine(path, $"{jsonName}.json");

        if (!File.Exists(jsonPath))
            return null;

        List<ToyotaTableGroup> result = null;

        using (StreamReader stream = new(jsonPath))
        {
            string json = stream.ReadToEnd();
            try
            {
                result = JsonSerializer.Deserialize<List<ToyotaTableGroup>>(json, options);
            }
            catch
            {
                return null;
            }
        }

        return result;
    }
}
