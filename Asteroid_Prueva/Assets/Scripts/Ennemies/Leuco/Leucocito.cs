using System.Collections;
using UnityEngine;

public class Leucocito : MonoBehaviour
{
    public GameObject granitos;
    public Collider2D leuco;
    public Animator anim;

    public bool catched;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (leuco.IsTouching(collision))
            {
                catched = true;
                collision.transform.SetParent(transform);
                player = collision.gameObject;
                collision.attachedRigidbody.linearVelocity = Vector2.zero;
                granitos.SetActive(true);
            }
        }
        
    }

    private void Update()
    {
        if (catched)
        {
            player.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void KillLeuco()
    {
        player.transform.SetParent(null);
        anim.SetTrigger("Die");
        Destroy(this.gameObject, 0.2f);
    }
}
