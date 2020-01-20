using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    public float curSpeed;
    public string leftControl;
    public string rightControl;
    public float defSpeed;

    public int favoredDirection;

    public Vector3 startLocation;

    public int dir = 0; //-1 left, 0 neither, 1 right
    private bool leftHeld = false;
    private bool rightHeld = false;

    public Color defaultColor;
    public Color disabledColor;

    private Rigidbody2D rb2d;

    public gameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = this.transform.Find("Player").GetComponent<SpriteRenderer>().color;
        disabledColor = (this.defaultColor+Color.black)/2;
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

        if (GetComponent<attack>().disabled)
        {
            this.transform.Find("Player").GetComponent<SpriteRenderer>().color = disabledColor;
        }
        else
        {
            this.transform.Find("Player").GetComponent<SpriteRenderer>().color = defaultColor;
        }
    }

    public void reset()
    {
        rb2d.velocity = new Vector3 (0, 0 ,0);
        transform.Find("Player").transform.position = startLocation;
        dir = 0;
        leftHeld = Input.GetAxisRaw(leftControl)==1;
        rightHeld = Input.GetAxisRaw(rightControl)==1;

        if (leftHeld && rightHeld)
        {
            dir = favoredDirection;
        }
        else if (leftHeld)
        {
            dir = -1;
        }
        else if (rightHeld)
        {
            dir = 1;
        }

        GetComponent<attack>().disabled=false;
        GetComponent<attack>().attacking=false;
        GetComponent<attack>().attackFrame=0;
        GetComponent<moveParts>().offset=0;
        GetComponent<characterControl>().curSpeed=GetComponent<characterControl>().defSpeed;

        
    }

    void FixedUpdate()
    {   
        if (gm.firstCountdown || GetComponent<attack>().frozenFrames > 0)
            return;     
        //rb2d.velocity = new Vector3 (dir * curSpeed , rb2d.velocity.y, 0.0f);
        this.transform.Find("Player").transform.position = new Vector3 (this.transform.Find("Player").transform.position.x + ((float)dir*curSpeed) * (float)Time.deltaTime, this.transform.Find("Player").transform.position.y, this.transform.Find("Player").transform.position.z);
    }
}
