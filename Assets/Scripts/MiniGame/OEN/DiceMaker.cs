using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMaker : MonoBehaviour
{

    [SerializeField]private Dice Dice;
    [SerializeField] private GameObject DicePrefab;
    private Dice game;

    private int Summon = 1;
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DiceBatch()
    {
        if(OENGameManager.Instace.Score > 1)
        {
            Summon= 2;
        }
        if(OENGameManager.Instace.Score > 2)
        {
            Summon = 3;
        }
        if (OENGameManager.Instace.Score > 3)
        {
            Summon = 4;
        }


        for (int i = 0; i < Summon; i++) 
        {
            game = Instantiate(Dice,DicePrefab.transform);
            OENGameManager.Instace.DiceList.Add(game);
            game.transform.position = new Vector3(i-3, 0.5f, 0f);
           
        }
    }
    
}
