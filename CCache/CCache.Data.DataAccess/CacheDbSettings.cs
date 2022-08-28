namespace CCache.Data.DataAccess;

public class CacheDbSettings
{
    public string ConnectionString 
        => $"connection={Enum.Parse<LiteDB.ConnectionType>(ConnectionType)};filename={FileName};password={Password};initial size={InitialSize};readonly={ReadOnly};upgrade={Upgrade}";

    #region Connection String Settings
    
    public string ConnectionType { get; set; } = "Shared";
    public string FileName { get; set; } = @"exampleCache.db";
    public string Password { get; set; } = String.Empty;
    public long InitialSize { get; set; } = 4096;
    public bool ReadOnly { get; set; } = false;
    public bool Upgrade { get; set; } = false;
    
    #endregion
    
    #region Index Settings

    public IndexSettings IndexSettings { get; set; }
    
    #endregion
}

public class IndexSettings 
{
    
}