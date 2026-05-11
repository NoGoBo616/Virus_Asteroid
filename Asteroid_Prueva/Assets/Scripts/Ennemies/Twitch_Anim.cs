using Unity.VisualScripting;
using UnityEngine;

public class Twitch_Anim : MonoBehaviour
{
    public Animator anim;
    public Collider2D coll;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (coll.IsTouching(other)) anim.SetBool("Go", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Go", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Kabum");
        }
    }
}
