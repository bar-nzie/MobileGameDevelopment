using System.Collections;
using UnityEngine;

public class Tilting : MonoBehaviour
{
    private bool isPositive;
    private bool readyToGo;
    public GameObject basket;
    private float moveSpeed = 10f;
    public GameObject eggs;
    private float time;
    private float cooldown = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.gyro.enabled = true;
        StartCoroutine(phoneCheck());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.gyro.attitude);
        Debug.Log(isPositive);
        Debug.Log(Input.gyro.rotationRateUnbiased);

        float zValue = Input.gyro.attitude.z;

        if (readyToGo)
        {
            if (isPositive)
            {
                if (zValue > 0.5)
                {
                    basket.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
                if (zValue < 0.5)
                {
                    basket.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
            }
            if (!isPositive)
            {
                if (zValue > -0.5)
                {
                    basket.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                }
                if (zValue < -0.5)
                {
                    basket.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                }
            }
        }

        time += Time.deltaTime;

        if (time > cooldown)
        {
            time = 0;
            Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), 5f, 0f);
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
