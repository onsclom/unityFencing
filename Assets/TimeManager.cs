using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    public void slowDown()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
