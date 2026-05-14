using Unity.VisualScripting;
using UnityEngine;

public class Twitch_Anim : MonoBehaviour
{
    public Animator anim;
    public Collider2D coll;
    public Glob_Blanco velocidad;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (coll.IsTouching(other))
            {
                anim.SetBool("Go", true);
                velocidad.turnSpeed = 4; 
                velocidad.speed = 4;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Go", false);
            velocidad.turnSpeed = 2;
            velocidad.speed = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Kabum");
            Destroy(this.gameObject, 0.2f);
        }
    }
}
