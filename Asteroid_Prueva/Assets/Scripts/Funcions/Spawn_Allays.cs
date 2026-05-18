using System.Collections;
using UnityEngine;

public class Spawn_Allays : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject[] spawned;
    bool isSpawning;

    [Header("posicion")]
    public float posY;
    public float posX;

    private void Start()
    {
        isSpawning = false;

    }

    private void Update()
    {
        gameObject.transform.position = new Vector2(posX, posY);
        if (isSpawning == false)
        {
            Instantiate(spawned[Random.Range(0,2)], this.gameObject.transform.position, Quaternion.identity);
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
}
