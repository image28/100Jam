using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<string> musicTracks;
    // Start is called before the first frame update
    void Start()
    {
        musicTracks = new List<string>(System.IO.Directory.EnumerateDirectories("Assets/Resources/Games/2dPlatformer/Music"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
