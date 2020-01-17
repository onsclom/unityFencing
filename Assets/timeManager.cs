using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    public TimeManager timeManager;

    public void slowDown()
    {
        Time.timeScale = slowdownFactor;   
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
