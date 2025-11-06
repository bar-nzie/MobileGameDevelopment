using UnityEngine;

public class HayButton : MonoBehaviour
{
    public GameObject UI;
    public Storage storage;
    public HayCollect collection;
    public GameObject hayCollect;
    private int hay = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI = GameObject.Find("MainUI");
        storage = UI.GetComponent<Storage>();
    }

    public void Collect()
    {
        storage.IncreaseHay(hay);
        collection.Unready();
        hayCollect.SetActive(false);
    }

}
