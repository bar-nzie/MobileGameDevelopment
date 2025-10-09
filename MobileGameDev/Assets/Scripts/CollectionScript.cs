using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadyToCollect()
    {
        canvas.SetActive(true);
    }

    public void Collect()
    {
        Debug.Log("Collected");
    }

    public void NotReady()
    {
        canvas.SetActive(false);
    }
}
