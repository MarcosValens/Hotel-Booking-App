using HotelApp.Models;
using System.Text.Json;

namespace HotelApp.Services;

public class FsRepositoryService<T> : IRepositoryService<T> where T : class, IEntity
{
    private readonly string _folder;
    private readonly string _metaFile;
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    private Metadata _metadata;

    public FsRepositoryService(AppConfigModel config)
    {
        _folder = Path.Combine(config.FS_FOLDER ?? "Data", typeof(T).Name);
        Directory.CreateDirectory(_folder);
        _metaFile = Path.Combine(_folder, "_metadata.json");

        _metadata = File.Exists(_metaFile)
            ? JsonSerializer.Deserialize<Metadata>(File.ReadAllText(_metaFile)) ?? new()
            : new();
    }

    public IEnumerable<T> GetAll() =>
        Directory.GetFiles(_folder, "*.json")
                 .Where(f => !f.EndsWith("_metadata.json"))
                 .Select(f => JsonSerializer.Deserialize<T>(File.ReadAllText(f))!)
                 .ToList();

    public T? GetById(int id)
    {
        var file = Path.Combine(_folder, $"{id}.json");
        return File.Exists(file)
            ? JsonSerializer.Deserialize<T>(File.ReadAllText(file))
            : null;
    }

    public void Add(T entity)
    {
        entity.Id = ++_metadata.LAST_INDEX;
        SaveMetadata();
        var file = Path.Combine(_folder, $"{entity.Id}.json");
        File.WriteAllText(file, JsonSerializer.Serialize(entity, _options));
    }

    public void Update(int id, T entity)
    {
        var file = Path.Combine(_folder, $"{id}.json");
        if (File.Exists(file))
        {
            File.WriteAllText(file, JsonSerializer.Serialize(entity, _options));
        }
    }

    public void Delete(int id)
    {
        var file = Path.Combine(_folder, $"{id}.json");
        if (File.Exists(file))
            File.Delete(file);
    }

    private void SaveMetadata() =>
        File.WriteAllText(_metaFile, JsonSerializer.Serialize(_metadata, _options));
}
