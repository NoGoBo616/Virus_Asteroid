using UnityEngine;
using UnityEngine.UI;

public class M_x2 : MonoBehaviour
{
    public float time;
    public Image barra;
    public float valor;

    private void Update()
    {
        time = time - Time.deltaTime;
        Debug.Log(time);

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
