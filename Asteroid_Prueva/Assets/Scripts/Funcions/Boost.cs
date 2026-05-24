using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speed;
    public Player_ player;
    public GolpeCinemachine shake;
    public GameObject[] animaciones; 

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player_>();
        this.gameObject.transform.position = new Vector2(Random.Range(-20, 21), Random.Range(-10, 11));
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 90f));
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
