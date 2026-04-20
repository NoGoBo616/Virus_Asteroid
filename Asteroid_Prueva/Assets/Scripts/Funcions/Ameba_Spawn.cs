using System.Collections;
using UnityEngine;
 
public class Ameba_Spawn : MonoBehaviour
{ 
    public float time;
    public GameObject ameba;
    public Vector2 posicion;

    private void OnEnable()
    {
        posicion = new Vector2(Random.Range(-10, 11), Random.Range(-8, 9));
        time = Random.Range(30, 120);
        StartCoroutine(Spawnear());
    }

    IEnumerator Spawnear()
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Spawnear");
        Instantiate(ameba, posicion, Quaternion.identity);
        yield return null;
        Destroy(this.gameObject);
    }
} 
 