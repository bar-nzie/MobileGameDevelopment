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
        transform.LookAt(cam.transform.position);
    }
}
