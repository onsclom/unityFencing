using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftChar;
    public GameObject rightChar;

    public Transform leftPreFab;
    public Transform rightPreFab;

    public ParticleSystem particleSys;
    public int resetTime;

    private bool leftHit;
    private bool rightHit;
    private bool roundEnd;
    private int resetCountdown;

    public void collision(GameObject winner)
    {
        if (winner == leftChar)
        {
            print("left hit");
            leftHit = true;
        }
        else
        {
            print("right hit");
            rightHit = true;
        }
    }

    void Start()
    {
        roundEnd = false;
        leftHit = false;
        rightHit = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftHit || rightHit)
        {
            if (leftHit && rightHit)
            {
                print("TIE WOWw");
            }
            else if (leftHit)
            {
                print("left won!");

                particleSys.gameObject.transform.position = rightChar.transform.Find("Player").transform.position;
                var main = particleSys.main;
                main.startColor = rightChar.transform.Find("Player").gameObject.GetComponent<SpriteRenderer>().color;

                particleSys.Play();
                rightChar.SetActive(false);

                roundEnd = true;
                resetCountdown = resetTime;
            }
            else
            {
                print("right won!");

                particleSys.gameObject.transform.position = leftChar.transform.Find("Player").transform.position;
                var main = particleSys.main;
                main.startColor = leftChar.transform.Find("Player").gameObject.GetComponent<SpriteRenderer>().color;

                particleSys.Play();
                leftChar.SetActive(false);
                
                roundEnd = true;
                resetCountdown = resetTime;
            }
            leftHit = false;
            rightHit = false;
        }

        if (roundEnd)
        {
            resetCountdown-=1;
            
            if (resetCountdown < 0)
            {
                reset();
            }
        }
    }

    void reset()
    {
        print("RESET!");
        roundEnd = false;

        //delete both characters
        //recreate them?
        leftChar.SetActive(true);
        rightChar.SetActive(true);
    
    }
}

            
