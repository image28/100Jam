using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class GameParaser : MonoBehaviour
{
    public List<string> games;
    public GameObject buttonPrefab;
   
    [SerializeField]
    public GameObject[] buttonInstances;
    [SerializeField]
    private Button[] buttonInstancesScripts;

    // Start is called before the first frame update
    public void parase()
    {
        games = new List<string>(System.IO.Directory.EnumerateDirectories("Assets/Resources/Games"));

        buttonInstances = new GameObject[games.Count];
        buttonInstancesScripts = new Button[games.Count];

        for (int e=0; e < games.Count; e++)
        {
            string name = games[e].Split('\\')[1];
            buttonInstances[e] = (GameObject)Instantiate(buttonPrefab);
            buttonInstances[e].name = games[e].Split('\\')[1];
            buttonInstances[e].transform.parent = gameObject.transform;
            buttonInstancesScripts[e] = buttonInstances[e].GetComponent<Button>();
            buttonInstances[e].transform.GetChild(0).GetComponent<Text>().text = games[e].Split('\\')[1];
            buttonInstances[e].transform.localScale = Vector3.one;
    
            buttonInstancesScripts[e].onClick.AddListener(() => GameManager.Instance.music.play(name));
            

        }

    }
}
