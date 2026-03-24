using UnityEngine;

public class Destruct_Instance : MonoBehaviour
{
    public GameObject instancia;
    private void OnDestroy()
    {
        Instantiate(instancia, transform.position, Quaternion.identity);
    }
}
