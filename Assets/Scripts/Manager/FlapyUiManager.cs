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
    private int Scoreint;


    void Start()
    {
        //ReTurn = GetComponentInChildren<Button>(true);
        //StartButton = GetComponentInChildren<Button>(true);
        //ReStart = GetComponentInChildren<Button>(true);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ScoreSet(int i)
    {

        Scoreint += i;
        Score.text = Scoreint.ToString();
    }

    public void SetDonw()
    {
        ShowRule.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        ReTurn.gameObject.SetActive(false);
    }

    public void SetEnd()
    {
        CurrntScore.text = Scoreint.ToString();
        ScoreBoard.gameObject.SetActive(true);
        ReTurn.gameObject.SetActive(true);
        ReStart.gameObject.SetActive(true);
    }

}
