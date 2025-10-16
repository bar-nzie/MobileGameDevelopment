using UnityEngine;
using UnityEngine.InputSystem;

public class Shaking : MonoBehaviour
{
    private float accelerationSensitivity = 5f;
    private float accelerationVal;
    public Animator milking;

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        if (acceleration != null )
        {
            accelerationVal = acceleration.sqrMagnitude;
        }

        if (accelerationVal >= accelerationSensitivity)
        {
            Debug.Log(accelerationVal);
            Debug.Log("Read Acceleration");
            milking.SetBool("isMilking", true);
        }
        else
        {
            milking.SetBool("isMilking", false);
        }
    }
}
