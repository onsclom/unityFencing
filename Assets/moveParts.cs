using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveParts : MonoBehaviour
{
    GameObject player;
    GameObject light;
    GameObject sword;
    GameObject freeformLight;
    public float offset;
    public bool flipSwordSide = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = 0;
        player = this.transform.Find("Player").gameObject;
        sword = this.transform.Find("Sword").gameObject;
    }

    // Update is called once per frame
    public void Update()
    {
        if (flipSwordSide == true)
        {
            sword.transform.position = new Vector3(player.transform.position.x+offset*-1, player.transform.position.y+.25f, 0) + new Vector3(0,0,2);
        }
        else
        {
            sword.transform.position = new Vector3(player.transform.position.x+offset, player.transform.position.y+.25f, 0) + new Vector3(0,0,2);
        }

    }
}
