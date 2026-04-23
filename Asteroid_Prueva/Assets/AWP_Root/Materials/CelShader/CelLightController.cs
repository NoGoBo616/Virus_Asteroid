using UnityEngine;

public class CelLightController : MonoBehaviour
{
    public Material material;
    public Transform lightTransform;

    void Update()
    {
        if (material != null && lightTransform != null)
        {
            Vector3 dir = lightTransform.forward ;
            material.SetVector("_LightDir", dir);
        }
    }
}
