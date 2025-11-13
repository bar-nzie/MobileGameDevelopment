using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Shaking : MonoBehaviour
{
    private float accelerationSensitivity = 5f;
    private float accelerationVal;
    public Animator milking;
    private float elapsed;

    // Update is called once per frame
    void Update()
    {
        if (elapsed > 6)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            SceneManager.UnloadSceneAsync("MilkTheCow");
        }
        Vector3 acceleration = Input.acceleration;
        if (acceleration != null )
        {
            accelerationVal = acceleration.sqrMagnitude;
        }

        if (accelerationVal >= accelerationSensitivity)
        {
            Debug.Log(elapsed);
            milking.SetBool("isMilking", true);
            elapsed += Time.deltaTime;
        }
        else
        {
            milking.SetBool("isMilking", false);
        }
    }
}
