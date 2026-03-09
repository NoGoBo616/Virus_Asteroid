using UnityEngine;

public class Leucocito : MonoBehaviour
{
    public GameObject granitos;

    bool catched;
    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            catched = true;
            collision.transform.SetParent(transform);
            player = collision.gameObject;
            collision.attachedRigidbody.linearVelocity = new Vector3(0,0,0);
            //animacion
            granitos.SetActive(true);
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
        Destroy(this.gameObject);
    }
}
