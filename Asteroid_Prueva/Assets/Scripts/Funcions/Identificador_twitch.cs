using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Identificador_twitch : MonoBehaviour
{
    public Twitch_Spawn twitch;

    private void OnEnable()
    {
        twitch = FindAnyObjectByType<Twitch_Spawn>();
        twitch.channelInput = GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if (twitch == null)
        {
            twitch = FindAnyObjectByType<Twitch_Spawn>();
            twitch.channelInput = GetComponent<TMP_InputField>();
        }
    }

    public void Boton()
    {
        twitch.Iniciar();
    }
}
