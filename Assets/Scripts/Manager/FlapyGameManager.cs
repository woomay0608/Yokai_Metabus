using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapyGameManager : MonoBehaviour, IMiniGamable
{

    FlapyUiManager FlapyUiManager;

    public static FlapyGameManager FlapyGameManagers;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
        gameManager = GameManager.instance;

        FlapyGameManagers = this;
        FlapyUiManager = FindAnyObjectByType<FlapyUiManager>();


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
        SceneManager.LoadScene("MainScene");
    }
}
