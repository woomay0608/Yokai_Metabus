using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class ReaderBorad : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshPro Flapy;
   
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
        int number = 1;
        sb.Append("Flappy\n");

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

        Debug.Log("�������� ������Ʈ��: " + sb.ToString());

        if (Flapy != null)
            Flapy.text = sb.ToString();


    }
}
