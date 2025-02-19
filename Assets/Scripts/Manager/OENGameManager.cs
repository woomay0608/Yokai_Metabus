using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OENGameManager : MonoBehaviour, IMiniGamable
{
    [SerializeField]private Dice Dice;


    public int Score = 0;

    public int AllNumber = 0;

    public static OENGameManager Instace;

    private void Awake()
    {
        if (Instace == null) { Instace = this; }
    }
    void Start()
    {
        

    }
    public void GameEnd()
    {
        throw new System.NotImplementedException();
    }

    public void GameStart()
    {
        throw new System.NotImplementedException();
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
}
