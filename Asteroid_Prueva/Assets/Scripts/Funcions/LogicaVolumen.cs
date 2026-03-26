using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("GlobalAudio", 0.5f);
        slider.value = sliderValue;
        AudioListener.volume = sliderValue;

        RevisarSiEstoyMute();
    }

    public void ChageSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("GlobalAudio", sliderValue);
        AudioListener.volume = sliderValue;

        RevisarSiEstoyMute();
    }

    public void RevisarSiEstoyMute()
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }

 
}
