using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Game 
{
    public string wordGuess;
    public Game(Dictionarie dico)
    {
        wordGuess = dico.GetRandWord();                             // constructeur 
        wordGuess = wordGuess.ToLower();
        playedLetters = new List<string>(); 
    }

    public List<string> playedLetters;

    
    public int life = 7;                                                //Nombre de vie au star

    public bool IsWon()                                                 // Instancie mais les win
    {
        foreach (var letter in wordGuess)
        {
            if (!IsLetterPlayed(letter)) return false;
        }
        return true;
    }
   
   
    public void RemoveLife(int lostLife)                                   // fait perdre des vie en cas de faute 
    {
        life -= lostLife;
        
        if (life <= 0)
        {
            IHM.Instance.DisplayGameOverMenu(true);
        }
    }

    public bool WordToGuessContainsLetters(char letter)                    //surchage pour le char
    {
        return wordGuess.Contains(letter.ToString());
    }
    public bool WordToGuessContainsLetters(string letter)                   //sursarges pour le string
    {
        return wordGuess.Contains(letter.ToLower());
    }

    public bool IsLetterPlayed(char letter)                                //surchage pour le char
    {
        return playedLetters.Contains(letter.ToString());  
    }
    public bool IsLetterPlayed(string letter)                          //sursarges pour le string
    {
        return playedLetters.Contains(letter);
    }

    public void AddPlayedLetter(string letter)                              
    {
        if (!IsLetterPlayed(letter))
            playedLetters.Add(letter);
    }
}
