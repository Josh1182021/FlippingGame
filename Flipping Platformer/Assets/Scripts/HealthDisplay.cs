using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{

    [SerializeField] int health;
    [SerializeField] int numberOfHearts;

    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    Health healthClass;

    private void Start()
    {
        healthClass = GetComponent<Health>();
    }


    private void Update()
    {

        health = healthClass.GetCurrentHealth();
        numberOfHearts = healthClass.GetMaxHealth();

        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int index = 0; index < hearts.Length; index++)
        {

            if (index < health)
            {
                hearts[index].sprite = fullHeart;
            }
            else
            {
                hearts[index].sprite = emptyHeart;
            }

            if (index < numberOfHearts)
            {
                hearts[index].enabled = true;
            }
            else
            {
                hearts[index].enabled = false;
            }
        }
    }
}
