using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flux : MonoBehaviour
{

    FlipEffect flipEffect;
    Collider2D collider2D;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        flipEffect = GetComponent<FlipEffect>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
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
}
