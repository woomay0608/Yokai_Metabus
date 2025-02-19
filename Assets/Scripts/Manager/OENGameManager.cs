using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OENGameManager : MonoBehaviour, IMiniGamable
{
    [SerializeField]private Dice Dice;


    public int Score = 0;

    public int AllNumber = 0;

    [SerializeField] private Tong Tong;

    public List<Dice> DiceList = new List<Dice>();
    public static OENGameManager Instace;

    private void Awake()
    {
        if (Instace == null) { Instace = this; }
        //GameManager.instance.SetMini(this);

    }
    void Start()
    {
        Tong = FindAnyObjectByType<Tong>();

        StartCorou();

    }
    public void GameEnd()
    {
        throw new System.NotImplementedException();
    }

    public void GameStart()
    {
        



    }

    public void ReturnHome()
    {
        throw new System.NotImplementedException();
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
        Tong.StartCor();
        yield return new WaitForSeconds(3);
        Diceon();
    }

    public void StartCorou()
    {
        StartCoroutine(DiceGo());
    }

}
