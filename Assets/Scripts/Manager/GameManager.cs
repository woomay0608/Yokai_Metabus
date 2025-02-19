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

    //게임 최고 기록 저장할 곳
    private int FlapyBestScore = 0;

    public List<int> FlapyList = new List<int>();
    public int flapyBestScore { get => FlapyBestScore; set { flapyBestScore = value; } }

    private const string FlapyBestKey = "FlapyBestKey";


    private IMiniGamable currentMiniGame;


    private void Awake()
    {

        FlapyBestScore = PlayerPrefs.GetInt(FlapyBestKey, 0);

        if (instance == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        else
        {
            //
            Destroy(gameManager.gameObject);
        }
        
        uiManager = FindAnyObjectByType<UiManager>();
    }


    private void Start()
    {

        uiManager.ReaderBoardSet();

    }

    private void Update()
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


    public void FlapyUpdateScore(int  currentscore, ref int BestScore)
    {
       
        FlapyList.Add(currentscore);
        FlapyList.Sort();
        FlapyList.Reverse();

        if (FlapyList.Count > 5)
        {
            FlapyList.RemoveAt(5);
        }
        
        if (currentscore > BestScore) 
        {
            BestScore = currentscore;
            PlayerPrefs.SetInt(FlapyBestKey, BestScore);
        }

        foreach(int i in FlapyList)
        { Debug.Log(i); }


        uiManager.ReaderBoardSet();
    }
}
