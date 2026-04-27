using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player_ miScript))
        {
            miScript.thrust = speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player_ miScript))
        {
            miScript.thrust = 1;
        }
    }
}
