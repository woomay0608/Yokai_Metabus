using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMaker : MonoBehaviour
{

    [SerializeField]private GameObject Dice;
    private GameObject game;

    private int Summon = 0;
    // Start is called before the first frame update
    void Start()
    {
        DiceBatch();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DiceBatch()
    {
        if(OENGameManager.Instace.Score > 1)
        {
            Summon++;
        }
        if(OENGameManager.Instace.Score > 2)
        {
            Summon++;
        }
        if (OENGameManager.Instace.Score > 3)
        {
            Summon++;
        }


        for (int i = Summon; i <1+ Summon; i++) 
        {
            game = Instantiate(Dice);
            game.transform.position = new Vector3(i-3, 0.5f, 0f);
           
        }
    }
    
}
