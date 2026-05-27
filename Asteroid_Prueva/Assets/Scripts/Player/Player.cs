using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_ : MonoBehaviour
{
    public float thrust = 1;
    public float rotationSpeed = 200;
    public float rotationInput;
    bool advance;

    public Rigidbody2D rb;
    private bool cooldownS;
    private bool cooldownI;
    private bool cooldownB;
    private bool cooldown;
    private bool special;

    [Header("Live")]
    public float live;

    [Header("Objects")]
    public GameObject bulletPrefab;
    public GameObject shield;
    public GameObject body;
    public Collider2D detect;
    public GameObject bulletHellObject;
    public GameObject disparador;

    [Header("UI")]
    public Image escudoUI;
    public Image pinchoUI;
    public Image bulletUI;
    public GameObject enrredadera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldownS = true;
        cooldownI = true;
        cooldownB = true;
        cooldown = true;
        special = true;
        live = 1;
    }

    //Controles

    public void HandleRotate(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<float>();
    }

    public void HandleAdvance(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            advance = true;
        } 
        if (context.canceled)
        {
            advance = false;
        }
    }

    public void HandleShoot()
    {
        if (cooldown)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(11);
            }

            Instantiate(bulletPrefab, disparador.transform.position, transform.rotation);

            StartCoroutine(BalaCD());
        }
    }

    public void HandlePinchos()
    {
        if (cooldownS && special)
        {
            StartCoroutine(Shield());
        }
    }

    public void HandleBullet()
    {
        if (cooldownB && special)
        {
            StartCoroutine(BulletHell());
        }
    }

    public void HandleInvisible()
    {
        if (cooldownI && special)
        {
            StartCoroutine(Invisible());
        }
    }

    void Update()
    {
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        if (advance) rb.AddForce(transform.up * thrust);
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > 5)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * 5;
        }
    }

    //Corrutinas

    private IEnumerator Shield()
    {

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(5);
        }

        shield.SetActive(true);
        special = false;
        yield return new WaitForSeconds(2);
        shield.SetActive(false);
        special = true;
        StartCoroutine(CooldownShield());
        yield return null;
    }

    private IEnumerator Invisible()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(4);
        }
        body.gameObject.SetActive(false);
        detect.enabled = false;
        special = false;
        yield return new WaitForSeconds(2);
        body.gameObject.SetActive(true);
        detect.enabled = true;
        special = true;
        StartCoroutine(CooldownInvisible());
        yield return null;
    }

    private IEnumerator BulletHell()
    {

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(11);
        }

        bulletHellObject.SetActive(true);
        special = false;
        yield return new WaitForSeconds(0.25f);
        bulletHellObject.SetActive(false);
        special = true;
        StartCoroutine(CooldownBullet());
        yield return null;
    }

    private IEnumerator Daño()
    {
        body.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        body.gameObject.SetActive(true);
        yield return null;
    }

    private IEnumerator CooldownShield()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(4);
        }
        cooldownS = false;
        escudoUI.gameObject.SetActive(true);
        escudoUI.fillAmount = 0;

        float duration = 4;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            escudoUI.fillAmount = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        cooldownS = true;
    }

    private IEnumerator CooldownInvisible()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(4);
        }
        cooldownI = false;
        pinchoUI.gameObject.SetActive(true);
        pinchoUI.fillAmount = 0;

        float duration = 4;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            pinchoUI.fillAmount = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        cooldownI = true;
    }

    private IEnumerator CooldownBullet()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxSource.pitch = Random.Range(0.9f, 1.1f);
            AudioManager.Instance.PlaySFX(4);
        }
        cooldownB = false;
        bulletUI.gameObject.SetActive(true);
        bulletUI.fillAmount = 0;

        float duration = 4;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            bulletUI.fillAmount = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        cooldownB = true;
    }

    private IEnumerator BalaCD()
    {
        cooldown = false;
        yield return new WaitForSeconds(0.5f);
        cooldown = true;
        yield return null;
    }
}
