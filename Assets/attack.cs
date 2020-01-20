using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public string attackButton;    
    public float cooldownFrames;
    public bool disabled = false;

    public bool attacking = false;
    public float attackFrame = 0f;
    public float frozenFrames = 0;

    //weapon data
    private float weaponStartup = 3.0f;
    private float weaponOut = 10f;
    private float whiffLag = 30f;
    private float frozenLag = 15f;

    private moveParts moveParts;
    private characterControl charControl;

    void Start()
    {
        moveParts = GetComponent<moveParts>();
        charControl = GetComponent<characterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && Input.GetAxisRaw(attackButton)==1 && !disabled)
        {
            attacking = true;
        }

        if (frozenFrames > 0)
        {
            frozenFrames -= Time.deltaTime*60f;
        }

        if (attacking)
        {
            disabled = true;
            attackFrame += (float)Time.deltaTime * 60f;
            //print(attackFrame);
            //print("time delta is " + Time.deltaTime);
            cooldownFrames = whiffLag;
            frozenFrames = frozenLag;

            if (attackFrame <= weaponStartup)
            {
                changeWeaponOffset( (float)attackFrame/(float)weaponStartup );
            }
            if (attackFrame > weaponStartup)
            {
                changeWeaponOffset(1);
            }

            if (attackFrame > weaponStartup + weaponOut)
            {
                changeWeaponOffset(0);
                attacking = false;
                attackFrame = 0;
            }
        }

        if (disabled)
        {
            cooldownFrames -= Time.deltaTime*60f;
            
            if (cooldownFrames < 0)
            {
                disabled = false;
            }
        }
    }

    void FixedUpdate()
    {        
        
    }

    void attackUpdate()
    {
        
    }

    public void correctSword(float distance)
    {   
        //get distance between 2 chars
        attackFrame = (Mathf.Abs(distance)/weaponStartup)*weaponStartup; 
        print("distance is " + distance);
    }

    //this func expects float between 0 and 1
    void changeWeaponOffset(float newValue)
    {
        moveParts.offset=newValue;
    }
}
