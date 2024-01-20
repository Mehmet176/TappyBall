using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pipes;
    public float maxYPos;
    Vector3 spawnPos;

    public float spawnBreak;
    public bool spawnPipes;

    public static Spawner instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;

        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        spawnPipes = true;
        StartCoroutine("SpawnPipe");
    }

    IEnumerator SpawnPipe(){
        yield return new WaitForSeconds(0.5f);

        while (spawnPipes)
        {
            int randomPipe = Random.Range(0, pipes.Length);

            spawnPos.y = Random.Range(-maxYPos, maxYPos);

            Instantiate(pipes[randomPipe], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnBreak);
        }
    }
}
