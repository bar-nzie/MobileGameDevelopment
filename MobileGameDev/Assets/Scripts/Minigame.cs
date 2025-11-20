using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    public bool locked = false;
    public bool isCow = false;
    public bool isChickens = false;
    public bool isPig = false;
    public GameObject canvas;
    public CollectionScript collect;
    public GameObject ui;

    private void Start()
    {
        ui = GameObject.Find("MainUI");
    }
    public void StartMinigame()
    {
        if (!locked)
        {
            ui.SetActive(false);
            collect.collectBoost();
            if (isChickens)
            {
                SceneManager.LoadSceneAsync("Catch the eggs", LoadSceneMode.Additive);
                canvas.SetActive(false);
            }
            if (isCow)
            {
                SceneManager.LoadSceneAsync("MilkTheCow", LoadSceneMode.Additive);
                canvas.SetActive(false);
            }
            if (isPig)
            {
                SceneManager.LoadSceneAsync("Roll Da Pig", LoadSceneMode.Additive);
                canvas.SetActive(false);
            }
        }
    }
}
