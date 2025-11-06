using UnityEngine;

public class Pass : MonoBehaviour
{
    public Timer Timer;
    public GameObject time;
    
    public void StartTimer()
    {
        time.SetActive(true);
        Timer.StartRoutine();
    }
}
