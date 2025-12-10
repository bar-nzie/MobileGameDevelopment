using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);   
    }

    public void OnStart()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.UnloadSceneAsync("Startmenu");
    }
}
