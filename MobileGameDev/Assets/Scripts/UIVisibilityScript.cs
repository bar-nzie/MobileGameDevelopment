using UnityEngine;

public class UIVisibilityScript : MonoBehaviour
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

    public void ShowUI()
    {
        canvas.SetActive(true);
    }
}
