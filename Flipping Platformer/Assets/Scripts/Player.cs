using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Health health;
    SpriteRenderer spriteRenderer;
    [SerializeField] float invincibleTime = 3f;
    [SerializeField] float blinkSpeed = 0.1f;


    void Start()
    {
        health = GetComponent<Health>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            PlayerHasDied();
        }
    }

    private void PlayerHasDied()
    {

    }

    public void PlayerWasHit()
    {
        health.StartInvincible(invincibleTime);
        StartCoroutine(BlinkingManager());
    }

    private IEnumerator BlinkingManager()
    {
        Coroutine blinking = StartCoroutine(Blink());
        yield return new WaitForSeconds(invincibleTime);
        StopCoroutine(blinking);
        spriteRenderer.enabled = true;
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkSpeed);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
}
