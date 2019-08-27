public class GameManager : Singleton<GameManager>
{
    protected GameManager() { } // guarantee this will be always a singleton only - can't use the constructor!

    public settings[] preferences;
    public string currentGame;
    public MusicPlaylist music;
    public GameParaser gameDataLoader;
    public mapLoader map;

    void Start()
    {
        if ( gameDataLoader != null )
            gameDataLoader.parase();

        if ( map != null )
            map.loadMap();
    }
}
