using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OENUiManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject OddOrEven;
    [SerializeField] private Button Odd;
    [SerializeField] private Button Even;

  
    [SerializeField] private GameObject StartObj;
    [SerializeField] public Button StartBut;

    [SerializeField] public Button ReturnBut;

    [SerializeField] private GameObject GameLose;
    [SerializeField] public Button Retrybtn;

    [SerializeField] private TextMeshProUGUI Score;


    [SerializeField] private TextMeshProUGUI Best;
    [SerializeField] private TextMeshProUGUI Current;

    private void Awake()
    {
        Odd.onClick.AddListener(isodd);
        Even.onClick.AddListener(iseven);
    }

    public void SetScore(int i)
    {

        OENGameManager.Instace.Score += i;
        if(OENGameManager.Instace.Score >= 5 )
            GameManager.instance.IsRidingTwo = true;

        Score.text = OENGameManager.Instace.Score.ToString();
    }

    public void SetDown()
    {
        Score.gameObject.SetActive(false);
        Best.text = OENGameManager.Instace.BestScore.ToString();
        Current.text = OENGameManager.Instace.Score.ToString();
        GameLose.SetActive(true);
    }
    public void SetStart()
    {
        StartObj.SetActive(true);
    }
    public void SetStartDown()
    {
        StartObj.SetActive(false);
    }
    public void SetEndtDown()
    {
        GameLose.SetActive(false);
    }
    public void OESetAct()
    {
        if (OddOrEven != null)
        {
            OddOrEven.SetActive(true);
        }
    }

    public void OESetFalse()
    {
        if (OddOrEven != null)
        {
            OddOrEven.SetActive(false);
        }
    }
    private void isodd()
    {
        OENGameManager.Instace.IsOdd = true;
        OENGameManager.Instace.IsEven = false;
        OENGameManager.Instace.IsSelect = true;
    }
    private void iseven() 
    {
        OENGameManager.Instace.IsEven = true;
        OENGameManager.Instace.IsOdd = false;
        OENGameManager.Instace.IsSelect = true;
    }
}
