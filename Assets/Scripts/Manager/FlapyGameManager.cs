using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapyGameManager : MonoBehaviour, IMiniGamable
{

    FlapyUiManager FlapyUiManager;

    public static FlapyGameManager FlapyGameManagers;

    GameManager gameManager;


    public int Scoreint;
    public int BestScore;
    
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = GameManager.instance;

        if (FlapyGameManagers == null)
        {
            FlapyGameManagers = this;
        }
        else
        {
            Destroy(FlapyGameManagers.gameObject);
        }
        FlapyUiManager = FindAnyObjectByType<FlapyUiManager>();
    }
    void Start()
    {
        BestScore = gameManager.flapyBestScore;



        Time.timeScale = 0f;

        gameManager.SetMini(this);

        if (FlapyUiManager != null )
        {
            FlapyUiManager.StartButton.onClick.AddListener(GameStart);
            FlapyUiManager.ReStart.onClick.AddListener(Restart);
            FlapyUiManager.ReTurn.onClick.AddListener(ReturnHome);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        FlapyUiManager.ScoreSet(0);
        FlapyUiManager.SetDonw();
        Time.timeScale = 1f;
    }
    public void GameEnd()
    {
        gameManager.UpdateScore(Scoreint, ref BestScore);
        FlapyUiManager.SetEnd();
    }

    public void AddScore(int i )
    {
        FlapyUiManager.ScoreSet(i);
    }


    public void Restart()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void ReturnHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}
