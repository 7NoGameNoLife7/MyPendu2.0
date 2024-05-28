using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Game 
{
    public string wordGuess;
    public Game(Dictionarie dico)
    {
        wordGuess = dico.GetRandWord();
        wordGuess = wordGuess.ToLower();
        playedLetters = new List<string>(); 
        Debug.Log(wordGuess);
    }
    public List<string> playedLetters;

    
    public int life = 7;

    public bool IsWon()
    {
        foreach (var letter in wordGuess)
        {
            if (!IsLetterPlayed(letter)) return false;
        }
        return true;
    }
   
   
    public void RemoveLife(int lostLife)
    {
        life -= lostLife;
        
        if (life <= 0)
        {
            IHM.Instance.DisplayGameOverMenu(true);
        }
    }

    public bool WordToGuessContainsLetters(char letter)
    {
        return GameManager.instance.currentGame.wordGuess.Contains(letter.ToString());
    }
    public bool WordToGuessContainsLetters(string letter)
    {
        return GameManager.instance.currentGame.wordGuess.Contains(letter.ToLower());
    }

    public bool IsLetterPlayed(char letter )
    {
        return GameManager.instance.currentGame.playedLetters.Contains(letter.ToString());  
    }
}
