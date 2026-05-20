using System.Collections;
using UnityEngine;

public class Flora_Intestinal : MonoBehaviour
{
    public Player_ player;
    public float time;
    public Animator anim;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player_>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
            time = Random.Range(20, 61);
            StartCoroutine(Ralentizar());
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Ralentizar()
    {
        player.thrust = 0.2f;
        yield return new WaitForSeconds(time);
        player.thrust = 1;
        yield return null;
    }
}
