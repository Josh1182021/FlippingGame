using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    [SerializeField] Dialogue noCrystalsNoFlippedDialogue;
    [SerializeField] Dialogue yesCrystalNoFlippedDialogue;
    [SerializeField] Dialogue noCrystalsYesFlippedDialogue;
    [SerializeField] Dialogue yesCrystalYesFlippedDialogue;


    CrystalTracker crystalTracker;
    DialogueTrigger dialogueTrigger;
    FlipEffect flipEffect;
    Timer timer;

    bool triggeredRecently = false;

    private void Start()
    {
        crystalTracker = FindObjectOfType<CrystalTracker>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        flipEffect = GetComponent<FlipEffect>();
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<CharacterMovement>()) {return; }

        if (triggeredRecently) {return; }
        else
        {
            StartCoroutine(TriggeredNow());
        }
        bool hasCrystals = crystalTracker.GetCrystals() > 0;
        bool isFlipped = flipEffect.GetHasLevelFlipped();

        if (hasCrystals && isFlipped)
        {
            timer.AddTime(crystalTracker.timeValue * crystalTracker.GetCrystals());
            crystalTracker.SpendCrystals(crystalTracker.GetCrystals());
            dialogueTrigger.TriggerDialogue(yesCrystalYesFlippedDialogue);
            ReFlipLevel();
        }
        else if (hasCrystals && !isFlipped)
        {
            dialogueTrigger.TriggerDialogue(yesCrystalNoFlippedDialogue);
        }
        else if (!hasCrystals && isFlipped)
        {
            dialogueTrigger.TriggerDialogue(noCrystalsYesFlippedDialogue);
            ReFlipLevel();
        }
        else if (!hasCrystals && !isFlipped)
        {
            dialogueTrigger.TriggerDialogue(noCrystalsNoFlippedDialogue);
        }
    }

    IEnumerator TriggeredNow()
    {
        triggeredRecently = true;
        yield return new WaitForSeconds(3);
        triggeredRecently = false;
    }

    private void ReFlipLevel()
    {
        FindObjectOfType<CameraFollow>().FlipCamera();

        var flipEffects = FindObjectsOfType<FlipEffect>();

        foreach (var flipEffect in flipEffects)
        {
            flipEffect.LevelHasReFlipped();
        }
    }
}
