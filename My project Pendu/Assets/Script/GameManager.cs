using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Dictionarie dictionarie;
    public static GameManager instance;
    public Game currentGame;
    public AudioClip audioTrue, audioFalse, audioFond;
    private AudioSource audioSource;


    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        NewGame();                                                          // permet le lancement 
        audioSource.PlayOneShot(audioFond);                                 // pour le son 
        
    }

    public void NewGame()
    {
        currentGame = new Game(dictionarie);
        IHM.Instance.UpdateLetter();
        IHM.Instance.UpdateSprite();

    }

    public void CheckLetter(string letter)                                      //verification des lettres 
    {
        bool isGoodMove=IsGoodMove(letter);

        currentGame.AddPlayedLetter(letter);    

        if (isGoodMove)
        {
            
            if (currentGame.IsWon())
            {
                IHM.Instance.DisplayWin(true);
            }
            audioSource.PlayOneShot(audioTrue);

        }
        else
        {
            audioSource.PlayOneShot(audioFalse);
            currentGame.RemoveLife(1);
        }

        IHM.Instance.UpdateLetter();
        IHM.Instance.UpdateSprite();
        IHM.Instance.UpdatePlayLetter();
    }
    bool IsGoodMove(string letter) 
    {
        if (!currentGame.WordToGuessContainsLetters(letter))
            return false;

        if (currentGame.IsLetterPlayed(letter))
            return false;

        return true;
    }
}

