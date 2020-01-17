using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    public float curSpeed;
    public string leftControl;
    public string rightControl;
    public float defSpeed;

    public int dir = 0; //-1 left, 0 neither, 1 right
    private bool leftHeld = false;
    private bool rightHeld = false;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.transform.Find("Player").gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(leftControl))
        {
            leftHeld = true;
            dir = -1;
        }
        if (Input.GetButtonDown(rightControl))
        {
            rightHeld = true;
            dir = 1;
        }

        if (Input.GetButtonUp(leftControl))
        {
            leftHeld = false;
            if (rightHeld)
            {
                dir = 1;
            }
            else
            {
                dir = 0;
            }
        }
        if (Input.GetButtonUp(rightControl))
        {
            rightHeld = false;
            if (leftHeld)
            {
                dir = -1;
            }
            else
            {
                dir = 0;
            }
        }
    }

    void FixedUpdate()
    {        
        rb2d.velocity = new Vector3 (dir * curSpeed , rb2d.velocity.y, 0.0f);
        this.transform.Find("Player").transform.position = new Vector3 (this.transform.Find("Player").transform.position.x + ((float)dir*curSpeed) * (float)Time.deltaTime, this.transform.Find("Player").transform.position.y, this.transform.Find("Player").transform.position.z);
    }
}
