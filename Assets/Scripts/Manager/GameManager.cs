using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TMPro;
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

  
    /// /////////////////////////////////////////////////////////////
  


    [SerializeField] private TextMeshPro Flapy;
    private IMiniGamable currentMiniGame;


    private void Awake()
    {

        FlapyBestScore = PlayerPrefs.GetInt(FlapyBestKey, 0);

        if (instance == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameManager);
        }
        else if(instance != null)
        {
            //
            Destroy(gameManager.gameObject);
            return;
        }
        uiManager = UiManager.Instace;

    }


    private void Start()
    {
   
        ReaderBoardSet();

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


    public void FlappyUpdateScore(int  currentscore, ref int BestScore)
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


        ReaderBoardSet();
    }

    public void ReaderBoardSet()
    {
        StringBuilder sb = new StringBuilder();
        int number = 1;
        sb.Append("Flappy\n");

        if (GameManager.instance.FlapyList != null)
        {
            foreach (int i in GameManager.instance.FlapyList)
            {
                sb.Append($"{number}. {i.ToString()}\n");
                number++;

            }
        }
        else
        {
            Debug.Log("FlappyList가 널임");
        }

        Debug.Log("리더보드 업데이트됨: " + sb.ToString());

        if(Flapy != null)
        Flapy.text = sb.ToString();


    }
}
