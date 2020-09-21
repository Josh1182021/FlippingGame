using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTracker : MonoBehaviour
{

    [SerializeField] UpdateText text;

    int startingCrystals = 0;
    [SerializeField] int currentCrystals;
    public float timeValue = 60;

    private IEnumerator Start()
    {
        currentCrystals = startingCrystals;
        yield return new WaitForEndOfFrame();
        text.UpdateTextAs(currentCrystals.ToString());
    }

    public void IncreaseCrystals(int amountToAdd)
    {
        currentCrystals += amountToAdd;
        text.UpdateTextAs(currentCrystals.ToString());
    }

    public void SpendCrystals(int amountToSubtract)
    {
        currentCrystals -= Mathf.Clamp(amountToSubtract, 0, 999);
        text.UpdateTextAs(currentCrystals.ToString());
    }

    public int GetCrystals()
    {
        return currentCrystals;
    }
}
