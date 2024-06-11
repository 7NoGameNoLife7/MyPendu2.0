using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "dictionary")]
public class Dictionarie : ScriptableObject
{
    public List<string> words = new List<string>();                                             //Gere ma liste de mots 
    public string GetRandWord()                                                 
    {
        int index = Random.Range(0, words.Count);
        return words[index];
    }
    
}
