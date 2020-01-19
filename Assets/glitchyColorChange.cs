using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class glitchyColorChange : MonoBehaviour
{
    public string cur;
    public float upperRange;
    public float lowerRange;
    private int curChar;
    private bool currentlyColored;
    private float timeToWait;
    // Start is called before the first frame update
    void Start()
    {
        timeToWait = Random.Range(lowerRange, upperRange);
        currentlyColored = false;
        cur = GetComponent<UnityEngine.UI.Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToWait < 0)        
        {
            if (!currentlyColored)
            {
                //color a random character a random color
                int randChar = Random.Range(0,cur.Length);
                string firstPart = cur.Substring(0,randChar);
                string secondPart = cur.Substring( randChar+1,cur.Length-(randChar+1) );

                var colors = new List<string>() {"green", "red", "blue"};
                string randColor = colors[Random.Range(0, colors.Count)];

                GetComponent<UnityEngine.UI.Text>().text = firstPart + "<color=" + randColor + ">" + cur[randChar] + "</color>" + secondPart;
            }

            timeToWait = Random.Range(lowerRange, upperRange);
            currentlyColored = !currentlyColored;
        }
        else
        {
            timeToWait -= Time.deltaTime;
        }
    }
}
