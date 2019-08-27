using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickups : MonoBehaviour
{
    public int itemAmount;
    public Text itemCountText;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("item"))
        {
            itemAmount++;
            collision.gameObject.transform.position = Vector3.one*-100;
            itemCountText.text = "items : " + itemAmount.ToString();
           // collision.gameObject.SetVisible(false);
        }
    }
}
