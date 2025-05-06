using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject smallerAsteroidPrefab;
    public int size = 3;

    void Start()
    {
        MoveBlood();
    }

    void MoveBlood()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;
    }

    private void OnDisable()
    {
        if (size > 1)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newAsteroid = Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
                newAsteroid.GetComponent<Asteroid>().size = size - 1;
            }
        }
    }
}
