using UnityEngine;
using Cinemachine; // Unity 6 usa este namespace

public class GolpeCinemachine : MonoBehaviour
{
    private CinemachineImpulseSource miImpulso;

    void Start()
    {
        miImpulso = GetComponent<CinemachineImpulseSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Esta línea genera la sacudida usando la configuración del componente
            miImpulso.GenerateImpulse();
        }
    }
}
