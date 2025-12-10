using UnityEngine;
using UnityEngine.SceneManagement;

public class Blow : MonoBehaviour
{
    private AudioClip micClip;
    public string micDevice;
    public float loudness;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Microphone.devices.Length > 0)
        {
            micDevice = Microphone.devices[0];
            micClip = Microphone.Start(micDevice, true, 10, 44100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            SceneManager.UnloadSceneAsync("StripTheWool");
        }
        loudness = GetLoudnessFromMic();
        Debug.Log(loudness);
        if (loudness > 0)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    float GetLoudnessFromMic()
    {
        if (micClip == null) return 0;

        const int sampleSize = 256;
        float[] data = new float[sampleSize];
        int position = Microphone.GetPosition(micDevice) - sampleSize + 1;
        if (position < 0) return 0;
        micClip.GetData(data, position);

        float total = 0;
        foreach (float s in data) total += Mathf.Abs(s);

        return total / sampleSize;
    }
}
