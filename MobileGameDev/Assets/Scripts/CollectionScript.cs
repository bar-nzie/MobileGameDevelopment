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
    public GameObject ground;
    public InterstitialAd interstitialAd;

    public bool locked = false;
    public bool isCow = false;
    public bool isChickens = false;
    public bool isPig = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        UI = GameObject.Find("MainUI");
        storage = UI.GetComponent<Storage>();
        ground = GameObject.Find("ground");
        interstitialAd = ground.GetComponent<InterstitialAd>();
    }

    public void Collect()
    {
        Debug.Log("Collected");
        interstitialAd.ShowAd();
        if (isChickens)
        {
            storage.IncreaseEggs(value);
        }
        if (isPig)
        {
            storage.IncreaseWool(value);
        }
        if (isCow)
        {
            storage.IncreaseMilk(value);
        }
        visibility.SetFalse();
        canvas.SetActive(false);
    }

    public void collectBoost()
    {
        storage.DecreaseMinigame();
        Debug.Log("Collected");
        if (isChickens)
        {
            storage.IncreaseEggs(value * 2);
        }
        if (isPig)
        {
            storage.IncreaseWool(value * 2);
        }
        if (isCow)
        {
            storage.IncreaseMilk(value * 2);
        }
        visibility.SetFalse();
        canvas.SetActive(false);
    }
}
