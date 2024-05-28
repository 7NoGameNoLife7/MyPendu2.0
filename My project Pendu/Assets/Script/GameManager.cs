using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    // private bool win = false;

    public Dictionarie dictionarie;
    public static GameManager instance;
    public Game currentGame;
    public AudioClip audioTrue, audioFalse;
    private AudioSource audioSource;
    

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        NewGame();
        //DisplayGameOverMenu(false);
    }

    public void NewGame()
    {
        currentGame = new Game(dictionarie);
        IHM.Instance.UpdateLetter();
        IHM.Instance.UpdateSprite();

    }

    public void CheckLetter(string letter)
    {
        //currentGame.wordGuess.NoContains(letter);
        currentGame.wordGuess.Contains(letter);
        if (currentGame.wordGuess.Contains(letter))
        {
            Debug.Log(letter + " est contenue dans le mot");
            if (currentGame.IsWon())
            {

            }
            audioSource.PlayOneShot(audioTrue);

        }
        else
        {
            Debug.Log(letter + " n'est pas contenue dans le mot");
            audioSource.PlayOneShot(audioFalse);
            currentGame.RemoveLife(1);
     

        }

        if (!currentGame.playedLetters.Contains(letter))
            currentGame.playedLetters.Add(letter);
        IHM.Instance.UpdateLetter();
        IHM.Instance.UpdateSprite();
        IHM.Instance.UpdatePlayLetter();
    }
}
