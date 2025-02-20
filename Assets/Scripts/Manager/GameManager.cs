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
    public static GameManager instance;

    UiManager uiManager;


    //static GameManager gameManager;
    //public static GameManager instance { get { return gameManager; } }
    //      if (instance == null)
    //      {
    //          gameManager = this;
    //          DontDestroyOnLoad(gameManager);
    //}
    //      else if (instance != null)
    //{
    //    //
    //    Destroy(gameManager.gameObject);
    //    return;
    //}
    [SerializeField] private Slider RedSlider;
    float red;
    [SerializeField] private Slider GreenSlider;
    float green;
    [SerializeField] private Slider BlueSlider;
    float blue;

   

    [SerializeField] private Image SaZin;

    [SerializeField] private Player Player;

    [SerializeField] private ReaderBorad reader;

    public static UiManager UiManager { get { return UiManager; } }

    //���� �ְ� ��� ������ ��
    private int FlapyBestScore = 0;

    public List<int> FlapyList = new List<int>();
    public int flapyBestScore { get => FlapyBestScore; set { flapyBestScore = value; } }

    private const string FlapyBestKey = "FlapyBestKey";


    private int DiceBestScore = 0;

    public List<int> DiceList = new List<int>();

    public int DiceBestSc { get => DiceBestScore; set { DiceBestScore = value; } }
    private const string DiceBestKey = "DiceBestKey";




    /// /////////////////////////////////////////////////////////////




    private IMiniGamable currentMiniGame;


    private void Awake()
    {

        FlapyBestScore = PlayerPrefs.GetInt(FlapyBestKey, 0);
        DiceBestScore = PlayerPrefs.GetInt(DiceBestKey, 0);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
            //
            Destroy(this.gameObject);
            return;
        }
        uiManager = UiManager.Instace;



        if (FlapyList != null)
            foreach (int i in FlapyList)
            { Debug.Log(i); }
    }



    public void RedSet()
    {
        red = RedSlider.value;
        Debug.Log("����" + red);
        ColorChange();
    }
    public void BlueSet()
    {
        blue = BlueSlider.value;
        Debug.Log("���" + blue);
        ColorChange();
    }
    public void GreenSet()
    {
        green = GreenSlider.value;
        Debug.Log("�׸�" + green);
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
        if (currentMiniGame != null)
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


    public void FlappyUpdateScore(int currentscore, ref int BestScore)
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

        foreach (int i in FlapyList)
        { Debug.Log(i); }
    }

    public void DiceUpdateSocre(int currentscore, ref int BestScore)
    {
        DiceList.Add(currentscore);
        DiceList.Sort();
        DiceList.Reverse();
        
        if(DiceList.Count > 5) 
        {
            DiceList.RemoveAt(5);
        }

        if (currentscore > BestScore) 
        {
            BestScore = currentscore;
            PlayerPrefs.SetInt(DiceBestKey, BestScore);
        }
    }


}
