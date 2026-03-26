using UnityEngine;

public class Granitos_2 : MonoBehaviour
{
    public Granitos_1 padre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            padre.live = padre.live - 1;
            this.gameObject.SetActive(false);
        }
    }
}
