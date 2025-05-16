
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Crono: MonoBehaviour
{
    public int points = 5000;
    [Header("Time Stats")]
    [SerializeField] TMP_Text timerText;
    [SerializeField] bool isCountdown;
    float timeElapsed;
    [SerializeField] float timeCountdown;

    int minutes;
    int seconds;
    int cents;
    int lastSecond = -1; // Nuevo: para detectar cambio de segundo

    [Header("Effects")]
    [SerializeField] Color warningColor = Color.red;
    [SerializeField] float shakeIntensity = 3f;
    Vector3 originalTextPos;
    bool warningActive = false;

    [Header("Final Stretch Settings")]
    [SerializeField] int finalStretchMusicIndex = 1;
    bool finalStretchStarted = false;

    [Header("Zoom Animation")]
    [SerializeField] float zoomScale = 1.3f;
    [SerializeField] float zoomDuration = 0.2f;

    void Start()
    {
        originalTextPos = timerText.transform.localPosition;
    }

    void Update()
    {
        if (!isCountdown)
        {
            TimerUp();
        }
        else
        {
            TimerDown();

            if (timeCountdown <= 11f && !warningActive)
            {
                warningActive = true;
                timerText.color = warningColor;
            }

            if (warningActive)
            {
                ShakeText();
            }

            if (timeCountdown <= 11f && !finalStretchStarted)
            {
                finalStretchStarted = true;
                AudioManager.Instance.MusicSource.volume = 0.07f;
                AudioManager.Instance.PlayMusic(finalStretchMusicIndex);
            }

            if (timeCountdown <= 0)
            {
                timeCountdown = 0;
                if (GameManager.Instance.points < points)
                {
                    SceneManager.LoadScene(5);
                    gameObject.SetActive(false);
                }
                else
                {
                    SceneManager.LoadScene(6);
                    gameObject.SetActive(false);
                }


          

            }
        }
    }

    void TimerUp()
    {
        timeElapsed += Time.deltaTime;
        minutes = (int)(timeElapsed / 60);
        seconds = (int)(timeElapsed - minutes * 60);
        cents = (int)((timeElapsed - (int)timeElapsed) * 100);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }

    void TimerDown()
    {
        timeCountdown -= Time.deltaTime;
        minutes = (int)(timeCountdown / 60);
        seconds = (int)(timeCountdown - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Detectar cambio de segundo dentro de los últimos 10 segundos
        if (timeCountdown <= 11f && seconds != lastSecond)
        {
            lastSecond = seconds;
            StartCoroutine(ZoomTextEffect());
        }
    }

    void ShakeText()
    {
        float x = Random.Range(-1f, 1f) * shakeIntensity;
        float y = Random.Range(-1f, 1f) * shakeIntensity;
        timerText.transform.localPosition = originalTextPos + new Vector3(x, y, 0);
    }

    IEnumerator ZoomTextEffect()
    {
        Vector3 originalScale = timerText.transform.localScale;
        Vector3 targetScale = originalScale * zoomScale;

        float timer = 0f;
        while (timer < zoomDuration)
        {
            timerText.transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / zoomDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        timerText.transform.localScale = targetScale;

        timer = 0f;
        while (timer < zoomDuration)
        {
            timerText.transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / zoomDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        timerText.transform.localScale = originalScale;
    }
}
