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
        int ii = 0;
        ii += i;
        Score.text = ii.ToString();
    }

    public void SetDonw()
    {
        StartButton.gameObject.SetActive(false);
        ReTurn.gameObject.SetActive(false);
    }

    public void SetEnd()
    {
        ReTurn.gameObject.SetActive(true);
        ReStart.gameObject.SetActive(true);
    }

}
