using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(-500,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
