using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speed;
    public Player_ player;
    public GolpeCinemachine shake;
    public GameObject[] animaciones;

    [Header("Posiciones")]
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player_>();
        this.gameObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 270));
        animaciones[Random.Range(0,3)].gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.thrust = speed;
            shake.Sehekear();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(DetenerBoost());
        }
    }

    IEnumerator DetenerBoost()
    {
        yield return new WaitForSeconds(2);
        player.thrust = 1;
        yield return null;
    }
}
