using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{

    TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTextAs(string newText)
    {
        textComponent.text = newText;
    }

    public string GetCurrentText()
    {
        return textComponent.text;
    }
}
