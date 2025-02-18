using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    UiManager uiManager;

    public static GameManager instance { get { return gameManager; } }
    public static UiManager UiManager { get { return UiManager; } }


    private int CurrentScore;

    private void Awake()
    {
        if (instance == null)
        {
            gameManager = this;
            DontDestroyOnLoad(uiManager);
        }
        else
        {
            Destroy(gameManager);
        }
        uiManager = FindAnyObjectByType<UiManager>();
    }


    private void Start()
    {
        uiManager.OnScore(0);
    }
    public void Gameover()
    {
        uiManager.OnRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int i)
    {
        CurrentScore += i;
        uiManager.OnScore(CurrentScore);
    }



}
