using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class mapData
{
    [Tooltip("Assign colors to tiles")]
    public Color32 mapColourAssignments;
    [Tooltip("Tiles to assosiate with the pixel data (r,g,b values make up up 3 different levels/ y placement of objects")]
    public GameObject tile;
}

public class mapLoader : MonoBehaviour
{
    [Tooltip("Map file to load")]
    public Texture2D map;
    [Tooltip("Grouped map data format assignments")]
    public mapData[] mapFormat;
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

            for(int i=0; i < mapFormat.Length; i++)
            { 
                if ( mapFormat[i].mapColourAssignments.r == pixelData[e].r && mapFormat[i].mapColourAssignments.g == pixelData[e].g && mapFormat[i].mapColourAssignments.b == pixelData[e].b )
                {
                    GameObject temp = Instantiate(mapFormat[i].tile, position, Quaternion.identity);
                    down = temp.transform.TransformDirection(-Vector3.up);
                    temp.transform.parent = gameObject.transform;
                    i = mapFormat.Length;
                }  
            }
        }
    }

}
