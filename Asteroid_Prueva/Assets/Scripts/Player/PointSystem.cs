using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int points = 0;
    public GameObject VFX_puntos;

    private void OnDisable()
    {
        Instantiate(VFX_puntos, this.gameObject.transform.position, Quaternion.identity);
    }
}
