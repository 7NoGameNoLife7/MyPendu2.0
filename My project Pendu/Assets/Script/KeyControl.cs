using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    string buttonLetter;
    [SerializeField]TextMeshProUGUI text;

    public void Init (string letter)
    {
        this.buttonLetter = letter;
        text.text = letter;
    }
    public void OnClick()
    {
        Debug.Log( buttonLetter );
        GameManager.instance.CheckLetter(buttonLetter);
    }

}
