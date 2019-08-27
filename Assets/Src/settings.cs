using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class settings : MonoBehaviour
{
    [Range(0.0f, 1.0f)][Tooltip("String value for player preference of this object")]
    public float floatValue;
    [Range(0, 100)][Tooltip("Int value for player preference of this object")]
    public int intValue;
    [Tooltip("String value for player preference of this object")]
    public string stringValue;
    [Tooltip("Saves the value on exit")]
    public bool saveOnExit = true;

    public Slider sliderValue;
    public AudioSource volume;

    // Use this for initialization
    void Start()
    {
        if ( volume == null )
            if ((volume = GetComponent<AudioSource>()) == null)
                Debug.Log("No Audio Source on " + gameObject.name);

        if (floatValue == 1.0f)
        {
            // Float used
            floatValue = PlayerPrefs.GetFloat(gameObject.name + "Float");
            sliderValue = GetComponent<Slider>();
            sliderValue.value = floatValue;
        }

        if (intValue == 1)
        {
            // int used
            intValue = PlayerPrefs.GetInt(gameObject.name + "Int");
        }

        if (stringValue != string.Empty)
        {
            // string used
            stringValue = PlayerPrefs.GetString(gameObject.name + "String");
        }
    }

    public void Save()
    {
        if (PlayerPrefs.HasKey(gameObject.name + "Float"))
        {
            // Float used
            
            PlayerPrefs.SetFloat(gameObject.name + "Float", floatValue);
        }else if (PlayerPrefs.HasKey(gameObject.name + "Int"))
        {
            // int used
            PlayerPrefs.SetInt(gameObject.name + "Int", intValue);
        }else if (PlayerPrefs.HasKey(gameObject.name + "String"))
        {
            // string used
            PlayerPrefs.SetString(gameObject.name + "String", stringValue);
        }
    }

    public void reload()
    {
        Start();
    }

    public void OnApplicationQuit()
    {
        if (saveOnExit)
            Save();
    }

    public void OnValueChanged(float newValue)
    {
        floatValue = newValue;
        if ( volume != null )
        {
            volume.volume = floatValue;
        }

        Save();
    }
}
