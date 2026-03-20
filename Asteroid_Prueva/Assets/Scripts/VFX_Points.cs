using System.Collections;
using UnityEngine;

public class VFX_Points : MonoBehaviour
{
    public Player_ camara;
    public Vector3 posicionObjetivo; 
    public float velocidad = 5f;
    public float margenLlegada = 0.1f; 

    private void OnEnable()
    {
        camara = FindAnyObjectByType<Player_>();
        posicionObjetivo = camara.transform.position;
        StartCoroutine(MoverHaciaObjetivo());
    }

    private IEnumerator MoverHaciaObjetivo()
    {
        //yield return new WaitForSeconds(1)
        while (Vector3.Distance(transform.position, posicionObjetivo) > margenLlegada)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Objetivo alcanzado. Destruyendo objeto.");
        Destroy(gameObject);
    }
}
