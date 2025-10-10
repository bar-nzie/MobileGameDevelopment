using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject canvas;
    public Image fillBar;
    public GameObject readyImage;
    private float lengthOfWait = 20f;
    private bool ready;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRoutine()
    {
        ready = false;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        canvas.SetActive(true);

        float elapsed = 0f;

        while (elapsed < lengthOfWait)
        {
            elapsed += Time.deltaTime;
            float fill = Mathf.Clamp01(elapsed/lengthOfWait);
            fillBar.fillAmount = fill;
            yield return null;
        }
        canvas.SetActive(false);
        ready = true;
    }

    public bool isReady() { return ready; }

    public void SetReady(bool ready)
    {
        this.ready = ready;
        Debug.Log("Reset");
    }
}
