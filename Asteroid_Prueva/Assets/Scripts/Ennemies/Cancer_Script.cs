using UnityEngine;

public class Cancer_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Glob_Blanco perseguir;
    public Asteroid patrullar;
    public GameObject nubes;
    public Animator anim;

    private void OnEnable()
    {
        patrullar.speed = 3;
        perseguir.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Follow", true);
            patrullar.speed *= 2;
            perseguir.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(nubes, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
