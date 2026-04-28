using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int points;
    public int originalPoints;
    public GameObject VFX_puntos;
    public M_x2 duplicado;
    bool multiple;

    private void Awake()
    {
        originalPoints = points;
    }
    private void Update()
    {
        if(duplicado == null)
        {
            duplicado = FindAnyObjectByType<M_x2>();
            if (multiple == true)
            {
                multiple = false;
                points = originalPoints;
            }
        }
        
        if (duplicado != null && multiple == false) 
        {
            points = (int)(points * duplicado.valor);
            multiple = true;
        }
    }
    private void OnDisable()
    {
        Instantiate(VFX_puntos, this.gameObject.transform.position, Quaternion.identity);
    }
}
