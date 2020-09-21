using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{

    [SerializeField] int value = 1;
    FlipEffect flipEffect;
    Collider2D collider2D;
    SpriteRenderer spriteRenderer;
    bool canBeAdded = true;

    private void Start()
    {
        flipEffect = GetComponent<FlipEffect>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (flipEffect.GetHasLevelFlipped())
        {
            spriteRenderer.color = new Color(255, 255, 255, 0);
            collider2D.enabled = false;
        }
        else
        {
            spriteRenderer.color = new Color(255, 255, 255, 255);
            collider2D.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBeAdded)
        {
            canBeAdded = false;
            FindObjectOfType<CrystalTracker>().IncreaseCrystals(value);
            Destroy(gameObject);
        }
    }
}
