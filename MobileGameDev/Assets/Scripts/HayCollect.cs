using UnityEngine;

public class HayCollect : MonoBehaviour
{
    private float growTime = 5f;
    private float elapsed = 0;
    private bool ready = false;
    public GameObject readyImage;
    public GameObject hay;
    private Vector3 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        readyImage.SetActive(false);
        hay.transform.position = new Vector3(hay.transform.position.x, 0, hay.transform.position.z);
        target = new Vector3(hay.transform.position.x, 1, hay.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready)
        {
            elapsed += Time.deltaTime;
            hay.transform.position = Vector3.MoveTowards(hay.transform.position, target, 0.2f * Time.deltaTime);
        }
        if(elapsed > growTime)
        {
            ready = true;
            elapsed = 0;
            hay.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            readyImage.SetActive(true);
        }
    }

    public void Unready()
    {
        ready = false;
        hay.transform.position = new Vector3(hay.transform.position.x, 0, hay.transform.position.z);
    }
}
