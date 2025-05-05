using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plaqueta : MonoBehaviour
{
    public GameObject asteroidClonePrefab;
    public float cloneInterval = 3f;
    public float offsetDistance = 0.7f;
    public int limit;
    public int number;

    private float timer = 0f;

    Vector2 randomDirection;

    private void OnEnable()
    {
        Vector2[] directions = new Vector2[]
        {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
        };

        randomDirection = directions[Random.Range(0, directions.Length)];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cloneInterval)
        {
            SpawnCloneNextTo();
            timer = 0f;
        }
    }

    void SpawnCloneNextTo()
    {
        if (number < limit)
        {
            Vector2 spawnPosition = (Vector2)transform.position + randomDirection * offsetDistance;

            GameObject clone = Instantiate(asteroidClonePrefab, spawnPosition, Quaternion.identity);
            clone.transform.parent = this.transform;

            offsetDistance = offsetDistance + 0.7f;
            number = number + 1;
        }
    }
}
