using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] GameObject grass;
    [SerializeField] GameObject grass2;
    [SerializeField] GameObject branch;
    [SerializeField] GameObject mushroom;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrass();
    }

    private void GenerateGrass()
    {
        Vector3 spawnPos;
        for (int x = 0; x < 400; x++)
        {
            if (x < 100)
            {
                spawnPos = new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70));
                Instantiate(grass, spawnPos, Quaternion.identity);
                continue;
            }
            if (x < 200)
            {
                spawnPos = new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70));
                Instantiate(grass2, spawnPos, Quaternion.identity);
                continue;
            }
            if (x < 300)
            {
                spawnPos = new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70));
                Instantiate(branch, spawnPos, Quaternion.identity);
                continue;
            }
            if (x < 400)
            {
                spawnPos = new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70));
                Instantiate(mushroom, spawnPos, Quaternion.identity);
                continue;
            }
        }
    }
}
