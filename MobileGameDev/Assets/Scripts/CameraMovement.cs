using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private MobileInput mInput;
    Vector2 delta;
    private float speed = 0.1f;
    private float zoomSpeed = 1f;
    public Camera cam;
    private float prevMagnitude;
    private UIVisibilityScript UIPen;

    private void Awake()
    {
        
        mInput = new MobileInput();

        mInput.Game.Zoom.performed += ctx => CameraZoom(ctx.ReadValue<Vector2>().y * zoomSpeed);

        mInput.Game.Movement.performed += ctx => delta = ctx.ReadValue<Vector2>();
        mInput.Game.Movement.canceled += ctx => delta = Vector2.zero;

        mInput.Game.Press.performed += screenTap;

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

    private void screenTap(InputAction.CallbackContext context)
    {
        Vector2 screenPos;
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            screenPos = Mouse.current.position.ReadValue();
        }
        else if(Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            screenPos = Touchscreen.current.position.ReadValue();
        }
        else
        {
            return;
        }

        Ray ray = new Ray(cam.ScreenToWorldPoint(screenPos), cam.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000f))
        {
            if(hit.collider.tag == "pen")
            {
                UIPen = hit.collider.GetComponent<UIVisibilityScript>();
                UIPen.ShowUI();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(delta.x, 0f, delta.y) * speed;

        transform.Translate(move, Space.World);
    }

    private void CameraZoom(float increment) => Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView + increment, 30, 60);
}
