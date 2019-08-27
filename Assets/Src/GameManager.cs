using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    protected GameManager() { } // guarantee this will be always a singleton only - can't use the constructor!

    public settings[] preferences;
    public string currentGame;
    public MusicPlaylist music;
    public GameParaser gameDataLoader;
    public mapLoader map;
    public int goal = 0;
    public Text goalCountText;

    void Start()
    {
        if ( gameDataLoader != null )
            gameDataLoader.parase();

        if ( map != null )
            map.loadMap();
    }
}
