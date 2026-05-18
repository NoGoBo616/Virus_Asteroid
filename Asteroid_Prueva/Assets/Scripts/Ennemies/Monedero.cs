using UnityEngine;
using UnityEngine.UI;

public class Monedero : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float live;
    public int indice;
    public Image liveImg;
    public GameObject[] premio;
    GameManager manager;

    private void OnEnable()
    {
        MoveBlood();
        rb = GetComponent<Rigidbody2D>();
        manager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            live --;
            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > 10)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * 10;
        }
    }

    void MoveBlood()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Random.insideUnitCircle.normalized * speed;
    }

    public void Update()
    {
        liveImg.fillAmount = live / 3;
        if (live <= 0)
        {
            indice = Random.Range(0, 3);
            Instantiate(premio[indice], this.gameObject.transform.position, Quaternion.identity);
            if (indice == 1)
            {
                manager.points = manager.points + Random.Range(200, 500);
            }
            Destroy(this.gameObject);
        }
    }
}
