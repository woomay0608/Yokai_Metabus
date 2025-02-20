using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ReaderBorad : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshPro Flapy;
    [SerializeField] private TextMeshPro Dice;
   
    void Start()
    {
        ReaderBoardSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReaderBoardSet() //ReaderBoard���ٰ� ����
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        int number = 1;

        sb.Append("Flappy\n");
        sb2.Append("Dice\n");
        if (GameManager.instance.FlapyList != null)
        {
            foreach (int i in GameManager.instance.FlapyList)
            {
                sb.Append($"{number}. {i.ToString()}\n");
                number++;

            }
        }
        else
        {
            Debug.Log("FlappyList�� ����");
        }
        if(GameManager.instance.DiceList != null) 
        {
            foreach(int i  in GameManager.instance.DiceList)
            {
                sb2.Append($"{number - GameManager.instance.FlapyList.Count}. {i.ToString()}\n");
                number++;
            }
        }



        Debug.Log("�������� ������Ʈ��: " + sb.ToString());

        if (Flapy != null)
            Flapy.text = sb.ToString();
        if(Dice != null)
            Dice.text = sb2.ToString();


    }
}
