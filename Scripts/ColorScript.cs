using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    Transform[] transfrom;
    private void Awake()
    {
        transfrom = GetComponentsInChildren<Transform>();
        foreach (Transform t in transfrom)
        {
            if (t.GetComponent<SpriteRenderer>() != null)
            {
                t.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.75f,0.77f,1f,1f,0.25f,1f);
            } 
        }
    }
}
