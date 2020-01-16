using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveParts : MonoBehaviour
{

    GameObject player;
    GameObject light;
    GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
/*
        player = Find("Player");
        light = Find("Point Light 2D");
*/

        print("testing");
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
            else if (child.name=="Sword")
            {
                print("found!");
                sword=child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        light.transform.position = player.transform.position;
        sword.transform.position = new Vector3(player.transform.position.x+1, player.transform.position.y+.25f, 1.0f);
        
    }
}
