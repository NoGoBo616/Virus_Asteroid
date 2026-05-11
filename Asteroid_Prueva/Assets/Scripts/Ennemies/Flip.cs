using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField] bool flip;
    [SerializeField] Rigidbody2D rb;
    private void Update()
    {
        Flipear();
    }
    public void Flipear()
    {
        if (rb.linearVelocity.x > 0 && !flip)
        {
            flip = true;
            gameObject.transform.localScale = new Vector2(-3, 3);
        }
        if (rb.linearVelocity.x < 0 && flip)
        {
            flip = false;
            gameObject.transform.localScale = new Vector2(3, 3);
        }
    }
}
