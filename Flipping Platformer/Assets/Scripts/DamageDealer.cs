using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health otherHealth = collision.GetComponent<Health>();

        if (otherHealth)
        {
            otherHealth.DealDamage(damage);
        }
    }

}
