using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Colesterol : MonoBehaviour
{
    public Player_ player;
    public GameManager puntos;

    [Header("Obgetos temporales")]
    public GameObject lento;
    public GameObject resPoints;
    public GameObject vfxInstance;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player_>();
        puntos = FindAnyObjectByType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int dados;
            dados = Random.Range(0,2);

            if (dados == 0)
            {
                lento.SetActive(false);
                resPoints.SetActive(true);
                StartCoroutine(Restar());
            }
            if (dados == 1)
            {
                lento.SetActive(true);
                resPoints.SetActive(false);
                StartCoroutine(Lento());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Lento()
    {
        yield return new WaitForSeconds(2);
        player.thrust = 0.5f;
        yield return null;
    }

    IEnumerator Restar()
    {
        yield return new WaitForSeconds(2);
        Instantiate(vfxInstance, this.gameObject.transform.position, Quaternion.identity);
        puntos.points = puntos.points/2;
        yield return null;
    }

    private void OnDestroy()
    {
        player.thrust = 3;
    }
}
