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

    // Start is called before the first frame update
    void Start()
    {
        offset = 0;
        freeformLight = this.transform.Find("Freeform Light 2D").gameObject;
        player = this.transform.Find("Player").gameObject;
        light = this.transform.Find("Point Light 2D").gameObject;
        sword = this.transform.Find("Sword").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        light.transform.position = player.transform.position;
        sword.transform.position = new Vector3(player.transform.position.x+offset, player.transform.position.y+.25f, 1.0f);
        freeformLight.transform.position = sword.transform.position;
    }
}
