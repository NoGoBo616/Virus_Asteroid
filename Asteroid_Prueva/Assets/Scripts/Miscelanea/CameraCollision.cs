using UnityEngine;
using Cinemachine; // Unity 6 usa este namespace

public class GolpeCinemachine : MonoBehaviour
{
    private CinemachineImpulseSource miImpulso;

    void Start()
    {
        miImpulso = GetComponent<CinemachineImpulseSource>();
    }

    public void Sehekear()
    {
        miImpulso.GenerateImpulse();
    }
}
