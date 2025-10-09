using UnityEngine;
using UnityEngine.InputSystem;

public class UIVisibilityScript : MonoBehaviour
{
    private MobileInput mInput;
    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(false);
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Removals()
    {
        Debug.Log("Removal");
        canvas.SetActive(false);
    }

    public void ShowUI()
    {
        canvas.SetActive(true);
    }
}
