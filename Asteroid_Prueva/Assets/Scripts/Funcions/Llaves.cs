using UnityEngine;

public class Llaves : MonoBehaviour
{
    public ArcadeManager manager;
    public GameObject[] llaves;

    private void Start()
    {
        manager = FindAnyObjectByType<ArcadeManager>();
    }

    private void Update()
    {
        llaves[0].gameObject.SetActive(manager.llaves[0]);
        llaves[1].gameObject.SetActive(manager.llaves[1]);
        llaves[2].gameObject.SetActive(manager.llaves[2]);
        llaves[3].gameObject.SetActive(manager.llaves[3]);
    }
}
