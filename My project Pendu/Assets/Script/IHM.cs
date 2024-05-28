using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.UI;
using System.Security.Cryptography;
using Unity.Properties;


public class IHM : MonoBehaviour
{

    public static IHM Instance;
    public GameObject[] lifes = new GameObject[8];
    [SerializeField]
    TextMeshProUGUI life;

    [SerializeField] GameObject gameOverGo;
    [SerializeField] TextMeshProUGUI wordToGuess;
    [SerializeField] Sprite[] spriteArray;
    [SerializeField] Image imgPendu;
    [SerializeField] TextMeshProUGUI wordNotGuess;
    [SerializeField] GameObject gameWinGo;
    private int SpriteIndex
    {
        get
        {
            Debug.Log(GameManager.instance.currentGame);
            int index = GameManager.instance.currentGame.life - 1;
            index = Mathf.Clamp(index, 0, spriteArray.Length - 1);
            return index;

        }
    }


    void Start()

    {
        DisplayGameOverMenu(false);

        Debug.Log("nbre image " + lifes.Length);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void UpdateSprite()
    {

        imgPendu.sprite = spriteArray[SpriteIndex];
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DisplayGameOverMenu(bool setActive)
    {
        gameOverGo.SetActive(setActive);
    }

    public void IsWon(bool setActive)
    {
        gameWinGo.SetActive(setActive);
    } 

    public void UpdateLetter()
    {
        string word = string.Empty;
        foreach (char c in GameManager.instance.currentGame.wordGuess)
        {
            if (GameManager.instance.currentGame.IsLetterPlayed(c))
            {
                word += c;
            }
            else
            {
                word += " _ ";
            }
        }
        wordToGuess.text = word;
    }
    public void UpdatePlayLetter()
    {

        string word = string.Empty;
        foreach (string c in GameManager.instance.currentGame.playedLetters)
        {
            if (GameManager.instance.currentGame.WordToGuessContainsLetters(c)) continue;
            word = word + c + " ";
        }
        wordNotGuess.text = word;
    }
}
