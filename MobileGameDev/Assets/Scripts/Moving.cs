using UnityEngine;

public class Moving : MonoBehaviour
{
    public bool isChicken;
    public bool isCow;
    public bool isPig;
    public bool isHay;
    public Placement movement;
    public GameObject cam;
    public GameObject obj;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        movement = cam.GetComponent<Placement>();
    }
    public void OnMove()
    {
        if(isChicken)
        {
            movement.StartMovementChicken(obj);
        }
        if (isCow)
        {
            movement.StartMovementCow(obj);
        }
        if (isPig)
        {
            movement.StartMovementPig(obj);
        }
        if (isHay)
        {
            movement.StartMovementHay(obj);
        }
    }
}
