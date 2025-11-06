using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIVisibilityScript : MonoBehaviour
{
    private MobileInput mInput;
    public GameObject canvas;
    private bool feeding;
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

    public void SetTrue()
    {
        feeding = true;
    }

    public void SetFalse()
    {
        feeding = false;
    }

    public void Removals()
    {
        Debug.Log("Removal");
        canvas.SetActive(false);
    }

    public void ShowUI()
    {
        if (!feeding)
        {
            canvas.SetActive(true);
        }
    }
}
