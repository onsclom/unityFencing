using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public string attackButton;    
    public int cooldownFrames;
    public bool disabled = false;

    private bool attacking = false;
    private int attackFrame = 0;

    //weapon data
    private int weaponStartup = 3;
    private int weaponOut = 10;
    private int whiffLag = 30;

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

        if (attacking)
        {
            disabled = true;
            attackFrame += 1;
            cooldownFrames = 10;

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
                cooldownFrames = whiffLag;
            }
        }

        if (disabled)
        {
            cooldownFrames -= 1;
            
            if (cooldownFrames < 0)
            {
                disabled = false;
            }
        }

        if (disabled)
        {
            charControl.curSpeed = ( ( (float)whiffLag - (float)cooldownFrames ) / whiffLag ) * charControl.defSpeed;
        }
    }

    void attackUpdate()
    {
        
    }

    //this func expects float between 0 and 1
    void changeWeaponOffset(float newValue)
    {
        moveParts.offset=newValue;
    }
}
