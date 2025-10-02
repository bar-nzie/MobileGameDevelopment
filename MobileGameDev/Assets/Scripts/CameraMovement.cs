using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private MobileInput mInput;
    Vector2 delta;
    private float speed = 0.1f;
    private float zoomSpeed = 1f;
    public Camera cam;

    private Touchscreen ts;
    private float prevMagnitude;

    private void Awake()
    {
        
        mInput = new MobileInput();

        mInput.Game.Zoom.performed += ctx => CameraZoom(ctx.ReadValue<Vector2>().y * zoomSpeed);

        mInput.Game.Movement.performed += ctx => delta = ctx.ReadValue<Vector2>();
        mInput.Game.Movement.canceled += ctx => delta = Vector2.zero;

        mInput.Game.touch1.performed += _ =>
        {
            var magnitude = (mInput.Game.touch0.ReadValue<Vector2>() - mInput.Game.touch1.ReadValue<Vector2>()).magnitude;
            if (prevMagnitude == 0)
            {
                prevMagnitude = magnitude;
            }
            var difference = magnitude - prevMagnitude;
            prevMagnitude = magnitude;
            CameraZoom(difference * zoomSpeed);
        };
    }

    private void OnEnable()
    {
        mInput.Enable();
    }

    private void OnDisable()
    {
        mInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(delta.x, 0f, delta.y) * speed;

        transform.Translate(move, Space.World);
    }

    private void CameraZoom(float increment) => Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView + increment, 30, 60);
}
