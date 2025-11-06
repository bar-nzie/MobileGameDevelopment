using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject canvas;
    public Image fillBar;
    public TextMeshProUGUI timeLeft;
    public GameObject readyImage;
    private float lengthOfWait = 20f;
    public UIVisibilityScript visibility;
    public int cost = 5;
    public int hay;
    public GameObject UI;
    public Storage storage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(false);
        readyImage.SetActive(false);
        UI = GameObject.Find("MainUI");
        storage = UI.GetComponent<Storage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoutine()
    {
        hay = storage.RetrieveHay();
        if (hay >= cost)
        {
            StartCoroutine(StartTimer());
        }
        else
        {
            canvas.SetActive(false);
        }
    }

    private IEnumerator StartTimer()
    {
        canvas.SetActive(true);
        storage.DecreaseHay(cost);
        visibility.SetTrue();
        float elapsed = 0f;
        while (elapsed < lengthOfWait)
        {
            elapsed += Time.deltaTime;
            float remaining = lengthOfWait - elapsed;
            timeLeft.text = "Time Left: " + ((int)remaining).ToString();
            float fill = Mathf.Clamp01(elapsed/lengthOfWait);
            fillBar.fillAmount = fill;
            yield return null;
        }
        canvas.SetActive(false);
        readyImage.SetActive(true);
    }


}
