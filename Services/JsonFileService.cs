using System.Text.Json;
using AIToolFinder.Services;

public class JsonFileService<T> : IJsonFileService<T>
{
    private readonly string _filePath;

    public JsonFileService(string filePath)
    {
        _filePath = filePath;
        if (!File.Exists(_filePath))
            File.WriteAllText(_filePath, "[]");
    }

    public List<T> Read()
    {
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    public void Write(List<T> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
