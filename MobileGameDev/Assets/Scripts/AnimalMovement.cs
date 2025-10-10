using System.Buffers.Text;
using System.Collections;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public Transform pen;
    private Vector3 moveTo;
    private float speed = 1f;
    private float baseY;
    // Bounce settings
    private float bounceHeight = 0.5f;
    private float bounceSpeed = 10f;

    void Start()
    {
        baseY = transform.position.y;
        ChooseRandomPos();
        InvokeRepeating(nameof(ChooseRandomPos), 2f, 2f); // Change target every 2 seconds
    }

    void Update()
    {
        // Move towards the target position on the XZ plane
        Vector3 targetXZ = new Vector3(moveTo.x, baseY, moveTo.z);
        transform.position = Vector3.MoveTowards(transform.position, targetXZ, Time.deltaTime * speed);

        // Bounce up and down using sine wave
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, baseY + bounce, transform.position.z);

        // Face the movement direction
        Vector3 lookDirection = (moveTo - transform.position);
        lookDirection.y = 0f;
        if (lookDirection != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * 5f);
    }

    void ChooseRandomPos()
    {
        moveTo = new Vector3(
            pen.position.x + Random.Range(-4f, 4f),
            baseY,
            pen.position.z + Random.Range(-4f, 4f)
        );
    }
}
