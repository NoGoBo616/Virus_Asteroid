using UnityEngine;

public class Boton3D : MonoBehaviour
{
    private void OnMouseEnter()
    {
        this.gameObject.transform.localScale = new Vector3(2, 2, 2);
    }

    private void OnMouseExit()
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    void OnMouseDown()
    {
        Debug.Log("Clic detectado por OnMouseDown");
    }
}
