using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speed;
    public Player_ player;
    public GolpeCinemachine shake;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player_>();
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
