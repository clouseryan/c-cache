namespace CCache.Data.DataAccess;

public class CacheDbSettings
{
    public string ConnectionString 
        => $"connection={Enum.Parse<LiteDB.ConnectionType>(ConnectionType)};filename={FileName};password={Password};initial size={InitialSize};readonly={ReadOnly};upgrade={Upgrade}";
    public string ConnectionType { get; set; } = "Shared";
    public string FileName { get; set; } = @"exampleCache.db";
    public string Password { get; set; } = String.Empty;
    public long InitialSize { get; set; } = 4096;
    public bool ReadOnly { get; set; } = false;
    public bool Upgrade { get; set; } = false;
}