using UnityEngine;
using UnityEngine.UI;

public class Monedero : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int indice;
    public bool open;
    public GameObject[] premio;
    GameManager manager;
    public Animator anim;

    private void OnEnable()
    {
        MoveBlood();
        open = false;
        rb = GetComponent<Rigidbody2D>();
        manager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            anim.SetBool("Open", true);
            Destroy(collision.gameObject);
            open = true;
            rb.linearVelocity = Vector3.zero;
        }

        if (collision.CompareTag("Player"))
        {
            if (open)
            {
                indice = Random.Range(0, 3);
                Instantiate(premio[indice], this.gameObject.transform.position, Quaternion.identity);
                if (indice == 0)
                {
                    manager.points = manager.points + Random.Range(200, 500);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if  (open == false)
        {
            if (rb.linearVelocity.magnitude > 10)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * 10;
            }
        }
    }

    void MoveBlood()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Random.insideUnitCircle.normalized * speed;
    }
}
