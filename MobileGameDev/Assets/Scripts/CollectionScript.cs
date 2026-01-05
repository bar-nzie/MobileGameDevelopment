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
    public GameObject IAP;
    public IAPFarmHero nomore;

    public bool locked = false;
    public bool isCow = false;
    public bool isChickens = false;
    public bool isPig = false;

    public bool noads = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Vibration.Init();
        UI = GameObject.Find("MainUI");
        storage = UI.GetComponent<Storage>();
        ground = GameObject.Find("ground");
        interstitialAd = ground.GetComponent<InterstitialAd>();
        IAP = GameObject.Find("MainUI");
        nomore = IAP.GetComponent<IAPFarmHero>();
    }

    private void Update()
    {
        noads = nomore.SetNoads();
    }

    public void Collect()
    {
        Vibration.VibratePop();
        Debug.Log("Collected");
        if (!noads)
        {
            interstitialAd.ShowAd();

        }
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
