using UnityEngine;

public class Fago_Anim : MonoBehaviour
{
    public Animator anim;
    public GameObject aspirar;
    public GameObject target;
    public Leucocito fago;
    bool capturable;

    private void OnEnable()
    {
        anim.SetBool("Aspirando", false);
        aspirar.SetActive(false);
        anim.SetBool("Catched", false);
        target = null;
        capturable = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && capturable)
        {
            aspirar.SetActive(true);
            target = collision.gameObject;
            anim.SetBool("Aspirando", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target != null && collision.gameObject.CompareTag("Player") && capturable)
        {
            target.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && capturable)
        {
            anim.SetBool("Aspirando", false);
            target.transform.SetParent(null);
            aspirar.SetActive(false);
            target = null;
        }
    }

    private void FixedUpdate()
    {
        if (target != null) aspirar.transform.LookAt(target.transform.position);
        if (capturable == true)
        {
            if (fago.catched == true)
            {
                anim.SetBool("Aspirando", false);
                anim.SetBool("Catched", true);
                capturable = false;
            }
        }
    }
}
