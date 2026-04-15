using UnityEngine;

public class AmebaControl : MonoBehaviour
{
    public float lifeAmeba;
    public float timeAmeba;
    public Rigidbody2D rbAmeba;
    public bool flying;
    [SerializeField] float speed;
    public Vector3 destino;
    public float[] times;
    private object rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
    }
    private void OnEnable()
    {
        lifeAmeba = 1f;
        timeAmeba =times[Random.Range(0,7)];
    }

    // Update is called once per frame
    void Update()
    {

        if (timeAmeba > 0)
        {
            timeAmeba -= Time.deltaTime;

        }
        if (timeAmeba <= 0)
        {
            timeAmeba = 0;
        }

    }
    

    private void FixedUpdate()
    {
       MoveAmeba();

    }
    void MoveAmeba()
    {
        //rb.velocity= (Vector2)(destino - transform.position).normalized * speed;

        if (Vector2.Distance(transform.position, destino) <= 0.1f)
        {
            //rb.velocity = Vector2.zero;
            Debug.Log("llegue");
        }
    }
}
