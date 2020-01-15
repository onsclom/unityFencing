using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce;
    public float moveHorizontal;
    public string leftControl;
    public string rightControl;

    private int dir = 0; //-1 left, 0 neither, 1 right
    private bool leftHeld = false;
    private bool rightHeld = false;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw(rightControl) + -1*Input.GetAxisRaw(leftControl);
        //float moveVertical = Input.GetAxis("Vertical");
        
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
        rb2d.velocity = new Vector3 (dir * speed, rb2d.velocity.y, 0.0f);
    }
}
