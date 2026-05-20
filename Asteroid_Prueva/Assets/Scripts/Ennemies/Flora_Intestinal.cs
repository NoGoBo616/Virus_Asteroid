using System.Collections;
using UnityEngine;

public class Flora_Intestinal : MonoBehaviour
{
    public Player_ player;
    public float time;
    public Animator anim;
    public GolpeCinemachine shake;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player_>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shake.Sehekear();
            anim.SetTrigger("Attack");
            time = Random.Range(20, 61);
            StartCoroutine(Ralentizar());
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            shake.Sehekear();
            player.thrust = 1;
            player.enrredadera.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Ralentizar()
    {
        player.thrust = 0.2f;
        player.enrredadera.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        player.thrust = 1;
        player.enrredadera.gameObject.SetActive(false);
        yield return null;
    }
}
