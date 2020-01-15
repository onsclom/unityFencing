using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLight : MonoBehaviour
{

    GameObject player;
    GameObject light;
    // Start is called before the first frame update
    void Start()
    {
/*
        player = Find("Player");
        light = Find("Point Light 2D");
*/

        foreach (Transform child in transform)
        {
            if (child.name=="Player")
            {
                player=child.gameObject;
            }
            else if (child.name=="Point Light 2D")
            {
                light=child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        light.transform.position = player.transform.position;
    }
}
