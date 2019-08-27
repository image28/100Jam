using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapLoader : MonoBehaviour
{
    [Tooltip("Map file to load")]
    public Texture2D map;
    [Tooltip("Tiles to assosiate with the pixel data (r,g,b values make up up 3 different levels/ y placement of objects")]
    public GameObject[] Tiles;
    [Tooltip("Raw pixel data from the map file")]
    public Color32[] pixelData;
    [Tooltip("How far along x,y,z axis to space object placement")]
    public Vector3 spacing;

    public void loadMap()
    {
        Vector3 down = Vector3.zero;
        //pixelData = new Color32(map.width * map.height);
        pixelData = map.GetPixels32();
        int x, z;
        Vector3 position = Vector3.zero;
   

        for (int e=0; e < map.width*map.height; e++)
        {
            x = e % map.width;
            z = e / map.width;
            position.x = (float)x;
            position.y = 0.0f;
            position.z = (float)z;

            if (pixelData[e].r == 255)
            {
                GameObject temp = Instantiate(Tiles[0], position, Quaternion.identity);
                down = temp.transform.TransformDirection(-Vector3.up);
                temp.transform.parent = gameObject.transform;
                if (Physics.Raycast(temp.transform.position, down, 10))
                    Debug.Log("Landing!");
            }else if (pixelData[e].g == 255)
            {
                GameObject temp = Instantiate(Tiles[1], position, Quaternion.identity);
                down = temp.transform.TransformDirection(-Vector3.up);
                temp.transform.parent = gameObject.transform;
                if (Physics.Raycast(temp.transform.position, down, 10))
                    Debug.Log("Landing!");
            }
        }
    }

}
