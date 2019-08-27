using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MusicPlaylist : MonoBehaviour
{
    public List<string> musicTracks;
    public AudioSource musicSource;
    public AudioClip[] playlist;
    public string musicFolder;
    public string currentGame;
    public bool shuffle = false;
    public int current;
    public bool loop = true;

    public void play(string name)
    {
        Debug.Log(name);
        if ((name != currentGame) || (currentGame == string.Empty))
        {
            currentGame = name;
            startGame();
            playMusic();
        }
        else
        {
            playMusic();
        }
    }

    // Start is called before the first frame update
    public void startGame()
    {
        
        if ( musicTracks.Count != 0 )
        {
            if (currentGame != GameManager.Instance.currentGame )
            {
                musicTracks.Clear();
            }
        }

        GameManager.Instance.currentGame = currentGame;

        musicFolder = "Assets/Resources/Games/" + currentGame + "/Music/";

        if (currentGame != string.Empty)
        {
            musicTracks = new List<string>(System.IO.Directory.EnumerateFiles(musicFolder));
        }

        for( int e =0; e < musicTracks.Count; e++)
        {
            Debug.Log(musicTracks[e]);

        }
    }

    // Update is called once per frame
    public void playMusic()
    {
        if (playlist == null || playlist.Length == 0)
        { 
            musicFolder = "Games/" + currentGame + "/Music/";
            //Debug.Log(Resources.LoadAll<AudioClip>(musicFolder).Cast<AudioClip>().ToString());
            playlist = new AudioClip[Resources.LoadAll<AudioClip>(musicFolder).Length];
            playlist = Resources.LoadAll<AudioClip>(musicFolder);
        }
      
        musicSource.Stop();
        musicSource.PlayOneShot(playlist[current]);

        if ( current < playlist.Length-1 )
        {
            current++;
        }
        else
        {
            if (loop)
                current = 0;
        }
    }
}
