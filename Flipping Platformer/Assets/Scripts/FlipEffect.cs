using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEffect : MonoBehaviour
{

    bool hasLevelFlipped = false;

    public bool GetHasLevelFlipped()
    {
        return hasLevelFlipped;
    }

    public void LevelHasFlipped()
    {
        hasLevelFlipped = true;
    }

    public void LevelHasReFlipped()
    {
        hasLevelFlipped = false;
    }
        
}
