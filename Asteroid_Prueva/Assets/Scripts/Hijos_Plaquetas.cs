using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hijos_Plaquetas : MonoBehaviour
{
    public GameObject vfxApear;
    public GameObject vfxDispear;
    bool flip;

    private void OnEnable()
    {
        Instantiate(vfxApear, transform.position, Quaternion.identity);
    }

    private void OnDisable()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(1);
        }

        Instantiate(vfxDispear, transform.position, Quaternion.identity);
    }
}
