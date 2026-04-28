using UnityEngine;

public class Monedero : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float live;
    public int indice;
    public GameObject[] premio;
    private void OnEnable()
    {
        MoveBlood();
        rb = GetComponent<Rigidbody2D>();
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
        if (live <= 0)
        {
            indice = Random.Range(0, 3);
            Instantiate(premio[indice], this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
