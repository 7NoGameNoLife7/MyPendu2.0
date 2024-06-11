using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    string buttonLetter;
    [SerializeField]TextMeshProUGUI text;

    public void Init (string letter)                    //gere ma liste de lettre pour le clavier virtuelle 
    {
        this.buttonLetter = letter;
        text.text = letter;
    }
    public void OnClick()                                                   //Pour le fonctionnement de chaque boutton 
    {
        Debug.Log( buttonLetter );
        GameManager.instance.CheckLetter(buttonLetter);
    }

}
