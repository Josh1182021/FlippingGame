using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Health health;
    //int healthLastFrame;
    [SerializeField] float invincibleTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        //healthLastFrame = health.GetCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            PlayerHasDied();
        }

        //if (health.GetCurrentHealth() < healthLastFrame)
        //{
        //    Debug.Log("trying invinability");
        //    health.InvincibleManager(invincibleTime);
        //}

        //healthLastFrame = health.GetCurrentHealth();
    }

    private void PlayerHasDied()
    {

    }

    public void PlayerWasHit()
    {
        Debug.Log("trying invinability");
        health.StartInvincible(invincibleTime);
    }
}
