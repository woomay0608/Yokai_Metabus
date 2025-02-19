using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField]private Sprite[] DiceNumber;

    private SpriteRenderer Renderer;
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DiceSelect()
    {
        int Ran = Random.Range(1, DiceNumber.Length+1);

        if(Ran == 0)
        {
            Renderer.sprite = DiceNumber[0];
            OENGameManager.Instace.AllNumber += 1;
        }
        if(Ran == 1) 
        {
            Renderer.sprite = DiceNumber[1];
            OENGameManager.Instace.AllNumber += 2;
        }
        if(Ran == 2)
        {
            Renderer.sprite = DiceNumber[2];
            OENGameManager.Instace.AllNumber += 3;
        }
        if(Ran == 3) 
        {
            Renderer.sprite = DiceNumber[3];
            OENGameManager.Instace.AllNumber += 4;
        }
        if(Ran == 4)
        {
            Renderer.sprite = DiceNumber[4];
            OENGameManager.Instace.AllNumber += 5;
        }
        if(Ran == 5) 
        {
            Renderer.sprite = DiceNumber[5];
            OENGameManager.Instace.AllNumber += 6;
        }


    }
}
