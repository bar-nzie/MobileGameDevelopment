using System.Collections;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Transform pen;
    private Vector3 moveTo;
    private float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ChooseRandomPos());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, moveTo) <= 0.1f)
        {
            StartCoroutine(ChooseRandomPos());
        }
    }

    private IEnumerator ChooseRandomPos()
    {
        yield return new WaitForSeconds(Random.Range(1, 4));
        moveTo = new Vector3(pen.position.x + Random.Range(-4f, 4f), 0.4f, pen.position.z + Random.Range(-4f, 4f));
    }
}
