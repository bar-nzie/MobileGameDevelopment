using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    public bool locked = false;
    public bool isCow = false;
    public bool isChickens = false;
    public bool isPig = false;
    public GameObject canvas;
    public void StartMinigame()
    {
        if (!locked)
        {
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
