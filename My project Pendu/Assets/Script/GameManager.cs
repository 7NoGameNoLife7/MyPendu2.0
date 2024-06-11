using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Dictionarie dictionarie;
    public static GameManager instance;
    public Game currentGame;
    public AudioClip audioTrue, audioFalse, audioFond;                                  // cassette de mais son 
    private AudioSource audioSource;                                                   // letteur de son


    private void Awake()
    {
        instance = this;                                                                    // declare mon instance 
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        NewGame();                                                          // permet le lancement 
        audioSource.PlayOneShot(audioFond);                                 // pour le son 
        
    }

    public void NewGame()
    {
        currentGame = new Game(dictionarie);                            //Pour le lancement de la partie 
        IHM.Instance.UpdateLetter();
        IHM.Instance.UpdateSprite();

    }

    public void CheckLetter(string letter)                                      //verification des lettres 
    {
        bool isGoodMove=IsGoodMove(letter);

        currentGame.AddPlayedLetter(letter);    

        if (isGoodMove)
        {
            
            if (currentGame.IsWon())                                                //verifi si on gagne
            {
                IHM.Instance.DisplayWin(true);                                                              // lance le panel win 
            }
            audioSource.PlayOneShot(audioTrue);                                         //lance le son en cas de bonne selection 

        }
        else
        {
            audioSource.PlayOneShot(audioFalse);                                        // lance le son en cas de mauvaise selection 
            currentGame.RemoveLife(1);                                                      // fait perdre une vie 
        }

        IHM.Instance.UpdateLetter();
        IHM.Instance.UpdateSprite();
        IHM.Instance.UpdatePlayLetter();
    }
    bool IsGoodMove(string letter)                                                      //permet la verif pour la win 
    {
        if (!currentGame.WordToGuessContainsLetters(letter))
            return false;

        if (currentGame.IsLetterPlayed(letter))
            return false;

        return true;
    }
}

