using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leftChar;
    public GameObject rightChar;

    public void collision(GameObject winner)
    {
        if (winner == leftChar)
        {
            print("left won");
        }
        else
        {
            print("right won");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
