using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    UiManager uiManager;


    [SerializeField] private Slider RedSlider;
     float red;
    [SerializeField] private Slider GreenSlider;
    float green;
    [SerializeField] private Slider BlueSlider;
    float blue;

    [SerializeField] private Image SaZin;

    [SerializeField] private Player Player;

    [SerializeField] private ReaderBorad reader;
    public static GameManager instance { get { return gameManager; } }
    public static UiManager UiManager { get { return UiManager; } }

    //게임 최고 기록 저장할 곳
    private int FlapyBestScore = 0;

    
    public int flapyBestScore { get => FlapyBestScore; set { flapyBestScore = value; } }

    private const string FlapyBestKey = "FlapyBestKey";

  
    /// /////////////////////////////////////////////////////////////
  



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

        

        if(reader.FlapyList != null)
        foreach (int i in reader.FlapyList)
        { Debug.Log(i); }
    }



    public void RedSet()
    {
        red = RedSlider.value; 
        Debug.Log("레드" + red);
        ColorChange();
    }
    public void BlueSet() 
    {
        blue = BlueSlider.value;
        Debug.Log("블루"+blue);
        ColorChange();
    }
    public void GreenSet() 
    {
        green = GreenSlider.value;
        Debug.Log("그린" + green);
        ColorChange();
    }

    public void ColorChange()
    {
        SaZin.color = new Color(red, green, blue);
        Player.rbSprite.color = new Color(red, green, blue);
    }

    private void Start()
    {
   
        

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
       
        reader.FlapyList.Add(currentscore);
        reader.FlapyList.Sort();
        reader.FlapyList.Reverse();

        if (reader.FlapyList.Count > 5)
        {
            reader.FlapyList.RemoveAt(5);
        }
        
        if (currentscore > BestScore) 
        {
            BestScore = currentscore;
            PlayerPrefs.SetInt(FlapyBestKey, BestScore);
        }

        foreach(int i in reader.FlapyList)
        { Debug.Log(i); }


      
    }

    
}
