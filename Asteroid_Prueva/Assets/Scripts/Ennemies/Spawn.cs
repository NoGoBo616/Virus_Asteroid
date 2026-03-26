using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawned;
    public float timeToSpawn;
    bool isSpawning;

    public float posY;
    public float posX;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false;
        Recuento();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(posX, posY);

        if (isSpawning == false)
        {
            int randomSpawner = Random.Range(0, spawned.Length);
            Instantiate(spawned[randomSpawner], transform.position, Quaternion.identity);
            StartCoroutine(Spawning());
        }
    }

    private IEnumerator Spawning()
    {
        isSpawning = true;
        Position();
        yield return new WaitForSeconds(timeToSpawn);
        isSpawning = false;
        yield return null;
    }

    void Position()
    {
        posX = Random.Range(-12, 12);
        posY = Random.Range(-8, 8);
    }

    //Dificultad

    void Recuento()
    {
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        yield return new WaitForSeconds(30);
        timeToSpawn = timeToSpawn - 0.1f;
        Recuento();
        yield return null;
    }
}
