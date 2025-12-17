using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tilting : MonoBehaviour
{
    private bool isPositive;
    private bool readyToGo;
    public GameObject basket;
    private float moveSpeed = 10f;
    public GameObject eggs;
    private float time;
    private float cooldown = 2f;
    private float count;
    private float initialPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
        StartCoroutine(phoneCheck());
        Vibration.Init();
        initialPos = Input.gyro.attitude.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >=10)
        {
            Vibration.Vibrate();
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SampleScene"));
            SceneManager.UnloadSceneAsync("Catch the eggs");
        }
        Debug.Log(Input.gyro.attitude);
        Debug.Log(isPositive);
        Debug.Log(Input.gyro.rotationRateUnbiased);

        float zValue = Input.gyro.attitude.z;

        if (readyToGo)
        {
            if (isPositive)
            {
                if (zValue > (initialPos + 0.1))
                {
                    basket.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
                if (zValue < (initialPos - 0.1))
                {
                    basket.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
            }
            if (zValue > (initialPos + 0.1))
            {
                basket.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (zValue < (initialPos - 0.1))
            {
                basket.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }

        Vector3 basketPosition = basket.transform.position;
        basketPosition.x = Mathf.Clamp(basketPosition.x, -408f, -392f);
        basket.transform.position = basketPosition;

        time += Time.deltaTime;

        if (time > cooldown)
        {
            time = 0;
            Vector3 spawnPos = new Vector3(Random.Range(-408f, -392f), 5f, 0f);
            Instantiate(eggs, spawnPos, Quaternion.identity);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.CompareTag("Egg"))
        {
            Destroy(other.gameObject);
            Debug.Log("Destroyed");
            count++;
        }
    }

    private IEnumerator phoneCheck()
    {
        yield return new WaitForEndOfFrame();
        if (Input.gyro.attitude.z > 0)
        {
            isPositive = true;
        }
        else
        {
            isPositive = false;
        }
        readyToGo = true;
    }
}
