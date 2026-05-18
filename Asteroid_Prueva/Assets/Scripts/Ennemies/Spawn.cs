using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] tutorial;
    public GameObject[] pulmon;
    public GameObject[] estomago;
    public GameObject[] intestino;
    public GameObject[] corazon;
    public float timeToSpawn;
    public int max;
    public Levels_Manager nivel;
    bool isSpawning;

    public float posY;
    public float posX;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false;
        Recuento();
    }

    private void OnEnable()
    {
        nivel = FindAnyObjectByType<Levels_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(posX, posY);

        if (isSpawning == false)
        {
            int randomSpawner = Random.Range(0, 6);

            if (nivel == null)
            {
                Instantiate(tutorial[randomSpawner].gameObject, this.gameObject.transform.position, Quaternion.identity);
                StartCoroutine(Spawning());
            }
            if (nivel.nivelSeleccionado >= 3)
            {
                Instantiate(pulmon[randomSpawner].gameObject, this.gameObject.transform.position, Quaternion.identity);
            }
            if (nivel.nivelSeleccionado == 2)
            {
                Instantiate(estomago[randomSpawner].gameObject, this.gameObject.transform.position, Quaternion.identity);
            }
            if (nivel.nivelSeleccionado == 1)
            {
                Instantiate(intestino[randomSpawner].gameObject, this.gameObject.transform.position, Quaternion.identity);
            }
            if (nivel.nivelSeleccionado == 0)
            {
                Instantiate(corazon[randomSpawner].gameObject, this.gameObject.transform.position, Quaternion.identity);
            }
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
