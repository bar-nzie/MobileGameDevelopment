using UnityEngine;

public class UIPen : MonoBehaviour
{
    public GameObject cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = cam.transform.position;
        targetPos.x = transform.position.x;
        transform.LookAt(targetPos);

    }
}
