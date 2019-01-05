/// <summary>
/// 游戏入口。
/// </summary>
public partial class GameEntry
{
    public static DatabaseComponent Database { get; private set; }
    public static CommandComponent Command { get; private set; }
    public static GlobalConfigComponent GlobalConfig { get; private set; }
    public static TempDataComponent TempData { get; private set; }
    public static ServiceComponent Service { get; private set; }

    private static void InitCustomComponents()
    {
        Database = UnityGameFramework.Runtime.GameEntry.GetComponent<DatabaseComponent>();
        Command = UnityGameFramework.Runtime.GameEntry.GetComponent<CommandComponent>();
        GlobalConfig = UnityGameFramework.Runtime.GameEntry.GetComponent<GlobalConfigComponent>();
        TempData = UnityGameFramework.Runtime.GameEntry.GetComponent<TempDataComponent>();
        Service = UnityGameFramework.Runtime.GameEntry.GetComponent<ServiceComponent>();
    }
}
