using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftChar;
    public GameObject rightChar;

    public GameObject leftScoreObj;
    public GameObject rightScoreObj;
    public int leftScoreCount;
    public int rightScoreCount;

    public Transform leftPreFab;
    public Transform rightPreFab;

    public ParticleSystem particleSys;
    public int resetTime;

    private bool leftHit;
    private bool rightHit;
    private bool roundEnd;
    private float resetCountdown;

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
        //check if either y < -5
        if (leftChar.active && rightChar.active && leftChar.transform.Find("Player").transform.position.y <= -5)
        {
            rightHit = true;
        }
        else if (rightChar.active && rightChar.active && rightChar.transform.Find("Player").transform.position.y <= -5)
        {
            leftHit = true;
        }

        if (leftHit || rightHit)
        {
            if (leftHit && rightHit)
            {
                print("TIE WOWw");
            }
            else if (leftHit)
            {
                particleSys.gameObject.transform.position = rightChar.transform.Find("Player").transform.position + new Vector3(0,0,-5);
                var main = particleSys.main;
                main.startColor = rightChar.transform.Find("Player").gameObject.GetComponent<SpriteRenderer>().color;
                var shape = particleSys.shape;
                shape.rotation = new Vector3 (0, 45, 0);

                particleSys.Play();
                rightChar.SetActive(false);

                roundEnd = true;
                resetCountdown = (float)resetTime;

                leftScoreCount += 1;
            }
            else
            {
                particleSys.gameObject.transform.position = leftChar.transform.Find("Player").transform.position + new Vector3(0,0,-5);
                var main = particleSys.main;
                main.startColor = leftChar.transform.Find("Player").gameObject.GetComponent<SpriteRenderer>().color;
                var shape = particleSys.shape;
                shape.rotation = new Vector3 (0, -45, 0);

                particleSys.Play();
                leftChar.SetActive(false);
                
                roundEnd = true;
                resetCountdown = resetTime;

                rightScoreCount += 1;
            }
            leftHit = false;
            rightHit = false;
        }

        if (roundEnd)
        {
            resetCountdown-=1.0f*Time.deltaTime*60.0f;
            
            if (resetCountdown < 0)
            {
                reset();
            }
        }

        leftScoreObj.GetComponent<UnityEngine.UI.Text>().text = leftScoreCount.ToString();
        rightScoreObj.GetComponent<UnityEngine.UI.Text>().text = rightScoreCount.ToString();
    }

    void reset()
    {
        print("reset called");
        particleSys.Stop();
        particleSys.Clear();
        print("RESET!");
        roundEnd = false;

        //one of them should be inactive
        leftChar.SetActive(true);
        rightChar.SetActive(true);

        //call public reset function in character control for each
        leftChar.GetComponent<characterControl>().reset();
        rightChar.GetComponent<characterControl>().reset();
        
    }
}

            
