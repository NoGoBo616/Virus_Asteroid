using System.Collections;
using UnityEngine;

public class Curas : MonoBehaviour
{
    [Header("vidas")]
    public Live_System liveSistem;
    public float vidasSum;

    [Header("Movimiento")]
    public GameObject player;
    public float velocidad;
    public float margenLlegada;

    private void OnEnable()
    {
        liveSistem = FindAnyObjectByType<Live_System>();
        vidasSum = Random.Range(0.1f, 0.33f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            StartCoroutine(MoverHaciaObjetivo());
        }
    }

    private IEnumerator MoverHaciaObjetivo()
    {
        yield return new WaitForSeconds(1);

        while (Vector3.Distance(transform.position, player.gameObject.transform.position) > margenLlegada)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, velocidad * Time.deltaTime);
            yield return null;
        }

        liveSistem.vida = liveSistem.vida + vidasSum;
        Destroy(gameObject);
    }
}
