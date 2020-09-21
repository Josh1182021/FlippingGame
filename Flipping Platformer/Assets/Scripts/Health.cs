using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    [SerializeField] int maxHealth = 1;
    [SerializeField] int startingHealth = 1;
    [SerializeField] int currentHealth;

    bool canBeHit = true;

    bool attachedToPlayer = false;
    Player player;

    [Header("Effects")]
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip deathSound;

    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] ParticleSystem deathEffect;

    private void Start()
    {
        currentHealth = startingHealth;
        if (GetComponent<Player>())
        {
            attachedToPlayer = true;
            player = GetComponent<Player>();
        }
    }

    public void DealDamage(int damageDealt)
    {
        if (canBeHit)
        {
            currentHealth = Mathf.Clamp(currentHealth - damageDealt, 0, maxHealth);

            if (currentHealth <= 0)
            {
                PlayDeathEffects();
            }
            else
            {
                PlayHitEffects();
            }

            if (attachedToPlayer)
            {
                player.PlayerWasHit();
            }
        }
    }

    private void PlayDeathEffects()
    {
        if (deathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
        if (deathEffect)
        {
            ParticleSystem spawnedDeathEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(spawnedDeathEffect, 5f);
        }
    }

    private void PlayHitEffects()
    {
        if (hitSound)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
        if (hitEffect)
        {
            ParticleSystem spawnedHitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(spawnedHitEffect, 5f);
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void StartInvincible(float timeInvincible)
    {
        StartCoroutine(ObjectIsInvincible(timeInvincible));
    }

    public IEnumerator ObjectIsInvincible(float timeInvincible)
    {
        canBeHit = false;
        Debug.Log("invincable");
        yield return new WaitForSeconds(timeInvincible);
        canBeHit = true;
        Debug.Log("can be hit");
    }


}
