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
        flip = Random.Range(0, 2) == 0;

        if (flip)
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 2);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(2, 2, 2);
        }
    }

    private void OnDisable()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(1);
        }
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(vfxDispear, transform.position, Quaternion.identity);
    }
}
