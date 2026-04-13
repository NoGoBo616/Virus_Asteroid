using UnityEngine;

public class MirarObgeto : MonoBehaviour
{
    public GameObject objeto_seguido;
    void Update()
    {
        this.gameObject.transform.LookAt(objeto_seguido.transform.position);
    }
}
