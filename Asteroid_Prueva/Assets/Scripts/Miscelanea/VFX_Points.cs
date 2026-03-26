using System.Collections;
using UnityEngine;

public class VFX_Points : MonoBehaviour
{
    public Player_ camara;
    public float velocidad = 5f;
    public float margenLlegada = 0.1f; 

    private void OnEnable()
    {
        camara = FindAnyObjectByType<Player_>();
        StartCoroutine(MoverHaciaObjetivo());
    }

    private IEnumerator MoverHaciaObjetivo()
    {
        yield return new WaitForSeconds(0.6f);
        while (Vector3.Distance(transform.position, camara.gameObject.transform.position) > margenLlegada)
        {
            transform.position = Vector3.MoveTowards(transform.position, camara.gameObject.transform.position, velocidad * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Objetivo alcanzado. Destruyendo objeto.");
        Destroy(gameObject);
    }
}
