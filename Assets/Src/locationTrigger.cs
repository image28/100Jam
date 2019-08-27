using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class locationTrigger : MonoBehaviour
{
    public Text goalCountText;

    void Start()
    {
        goalCountText=GameManager.Instance.goalCountText;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Contains("pushable"))
        {
            GameManager.Instance.goal--;
            goalCountText.text = "goals : " + GameManager.Instance.goal;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("pushable"))
        {
            GameManager.Instance.goal++;
            goalCountText.text = "goals : " + GameManager.Instance.goal;
        }
    }
}
