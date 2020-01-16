using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public string attackButton;    
    public int cooldownFrames;

    private bool attacking = false;
    private int attackFrame = 0;

    //weapon data
    private int weaponStartup = 3;
    private int weaponOut = 10;
    private int whiffLag = 25;

    void Start()
    {
        print(gameObject.GetComponent<moveParts>().offset);
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && Input.GetButtonDown(attackButton))
        {
            print("attack");
            attacking = true;
        }

        if (attacking)
        {
            attackFrame+=1;

            if (attackFrame > weaponStartup)
            {
                changeWeaponOffset(1);
            }

            if (attackFrame > weaponStartup + weaponOut)
            {
                changeWeaponOffset(0);
                attacking=false;
                attackFrame = 0;
            }
        }
    }

    void attackUpdate()
    {
        
    }

    void changeWeaponOffset(float newValue)
    {
        gameObject.GetComponent<moveParts>().offset=newValue;
    }
}
