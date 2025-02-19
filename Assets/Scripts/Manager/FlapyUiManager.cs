using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlapyUiManager : MonoBehaviour
{
    
    public TextMeshProUGUI Score;
    public Button ReTurn;
    public Button StartButton;
    public Button ReStart;
    public GameObject ShowRule;
    public GameObject ScoreBoard;
    public TextMeshProUGUI Best;
    public TextMeshProUGUI CurrntScore;

    FlapyGameManager FlapyGameManager;

    void Start()
    {

        FlapyGameManager = FindAnyObjectByType<FlapyGameManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ScoreSet(int i)
    {

        FlapyGameManager.Scoreint += i;
        Score.text = FlapyGameManager.Scoreint.ToString();
    }

    public void SetDonw()
    {
        ShowRule.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        ReTurn.gameObject.SetActive(false);
    }

    public void SetEnd()
    {
        Best.text = FlapyGameManager.BestScore.ToString();
        CurrntScore.text = FlapyGameManager.Scoreint.ToString();
        ScoreBoard.gameObject.SetActive(true);
        ReTurn.gameObject.SetActive(true);
        ReStart.gameObject.SetActive(true);
    }

}
