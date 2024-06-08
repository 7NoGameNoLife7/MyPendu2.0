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
        return wordGuess.Contains(letter.ToString());
    }
    public bool WordToGuessContainsLetters(string letter)
    {
        return wordGuess.Contains(letter.ToLower());
    }

    public bool IsLetterPlayed(char letter )
    {
        return playedLetters.Contains(letter.ToString());  
    }
    public bool IsLetterPlayed(string letter)
    {
        return playedLetters.Contains(letter);
    }

    public void AddPlayedLetter(string letter)
    {
        if (!IsLetterPlayed(letter))
            playedLetters.Add(letter);
    }
}
