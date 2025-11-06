using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectionScript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject UI;
    public Storage storage;
    public int value = 5;
    public UIVisibilityScript visibility;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        UI = GameObject.Find("MainUI");
        storage = UI.GetComponent<Storage>();
    }

    public void Collect()
    {
        Debug.Log("Collected");
        storage.IncreaseStorage(value);
        visibility.SetFalse();
        canvas.SetActive(false);
    }
}
