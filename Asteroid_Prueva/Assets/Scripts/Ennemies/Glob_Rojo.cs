using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 5;
    public GameObject smallerAsteroidPrefab;
    public int size = 3;
    public GolpeCinemachine shake;
    
    public GameManager manager;
    [SerializeField] public int bulletSfxIndex;

    public GameObject vfxApear;
    public GameObject vfxDispear;

    private Rigidbody2D rb;
    public int pointsEn;

    private void OnEnable()
    {
        Instantiate(vfxApear, transform.position, Quaternion.identity);
        manager = FindAnyObjectByType<GameManager>();
    }

    void Start()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (size > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject newAsteroid = Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
                    newAsteroid.GetComponent<Asteroid>().size = size - 1;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnDisable()
    {
        shake.Sehekear();
        if (AudioManager.Instance != null)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
                AudioManager.Instance.PlaySFX(bulletSfxIndex);
            }
        }
        if (!this.gameObject.scene.isLoaded) return;
        manager.Puntuar(pointsEn);
        Instantiate(vfxDispear, transform.position, Quaternion.identity);
    }
}
