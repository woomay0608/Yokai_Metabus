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


    private IMiniGamable currentMiniGame;


    private void Awake()
    {
        if (instance == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        else
        {
            Destroy(gameManager);
        }
        
        uiManager = FindAnyObjectByType<UiManager>();
    }


    private void Start()
    {
    
        
    }

    public void SetMini(IMiniGamable mini)
    {
        currentMiniGame = mini;
    }
  
    public void StartMini()
    {
        if(currentMiniGame != null)
        {
            currentMiniGame.GameStart();
        }
    }

    public void EndGame()
    {
        if (currentMiniGame != null)
        {
            currentMiniGame.GameEnd();
        }
    }

    public void Return()
    {
        if (currentMiniGame != null)
        {
            currentMiniGame.ReturnHome();
        }
    }

}
