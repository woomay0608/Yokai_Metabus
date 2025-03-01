using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class OENGameManager : MonoBehaviour, IMiniGamable
{
    [SerializeField]private Dice Dice;


    public int Score = 0;

    public int AllNumber = 0;

    [SerializeField] private Tong Tong;

    public List<Dice> DiceList = new List<Dice>();
    public static OENGameManager Instace;

    private OENUiManager ENUiManager;


    [SerializeField] DiceMaker DiceMakers;
    [SerializeField] GameObject DiceDomb;

    public bool IsOdd = false;
    public bool IsEven = false;

    public bool IsSelect = false;

    public int BestScore = 0;

    private void Awake()
    {
        if (Instace == null) { Instace = this; }
        else { Destroy(this.gameObject); }
        //GameManager.instance.SetMini(this);
        ENUiManager = FindAnyObjectByType<OENUiManager>();
        Score = 0;
    }
    void Start()
    {
        Tong = FindAnyObjectByType<Tong>();

        BestScore = GameManager.instance.DiceBestSc;
        GameManager.instance.SetMini(Instace);

        Time.timeScale = 0f;

    


        ENUiManager.SetStart();

        if (ENUiManager != null)
        {
            
            ENUiManager.StartBut.onClick.AddListener(GameStart);
            ENUiManager.Retrybtn.onClick.AddListener(Retry);
            ENUiManager.ReturnBut.onClick.AddListener(ReturnHome);
        }



    }
    public void GameEnd()
    {
        GameManager.instance.DiceUpdateSocre(Score, ref BestScore);
        ENUiManager.SetDown();
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
        ENUiManager.SetStartDown();
        StartCorou();
    }

    public void Retry()
    {
        ENUiManager.SetEndtDown();
        Score = 0;
        StartCorou();

    }
    public void ReturnHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Diceon()
    {
        foreach (Dice d in DiceList) 
        {
            d.DiceSelect();
            d.gameObject.SetActive(true);
        }
    }


    private IEnumerator DiceGo()
    {
       
        IsOdd = false;
        IsEven = false;
        IsSelect = false;

        DiceDel();
        DiceList.RemoveRange(0, DiceList.Count);
        AllNumber = 0;


        DiceMakers.DiceBatch();
        Tong.StartCor();


        ENUiManager.OESetAct();
        yield return new WaitUntil(() => IsSelect);
        ENUiManager.OESetFalse();
        Diceon();


        yield return new WaitForSeconds(2);
        compare();
    }

    public void StartCorou()
    {
        StartCoroutine(DiceGo());
    }

    private void compare()
    {
        if(AllNumber % 2 ==0)
        {
            if(IsOdd)
            {
                GameEnd();
            }
            else
            {
                ENUiManager.SetScore(1);
                StartCorou();
            }
            
        }
        else
        {
            if (IsOdd)
            {
                ENUiManager.SetScore(1);
                StartCorou();
            }
            else
            {
                GameEnd();
            }
        }
    }

    public void DiceDel()
    {
        
        if(DiceDomb != null )
        {
            foreach (Transform child in DiceDomb.transform)
            {
                Destroy(child.gameObject);
            }
        }

    }
}
