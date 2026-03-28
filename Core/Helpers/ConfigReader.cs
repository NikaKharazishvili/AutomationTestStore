using System.Text.Json;

namespace Core.Helpers;

/// <summary>Reads test configuration from appsettings.json copied to the output directory.</summary>
public static class ConfigReader
{
    static readonly JsonElement _config = JsonDocument.Parse(File.ReadAllText("appsettings.json")).RootElement;

    public static string Get(string key)
    {
        var parts = key.Split(':');
        var element = _config;
        foreach (var part in parts)
            element = element.GetProperty(part);
        return element.GetString() ?? throw new Exception($"Config key '{key}' is null");
    }
}