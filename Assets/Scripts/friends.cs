using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class friends : MonoBehaviour
{

   
    [SerializeField] private TMP_Text talkText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //


    //�浹�� �������ִ� �޼ҵ�
    //Collistion/ Trigger
    //enter , stay, Exit

    private void OnCollisionEnter2D(Collision2D collision)
    {
        talkText.gameObject.SetActive(true);
        Debug.Log("�ȳ�");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        talkText.gameObject.SetActive(false);
        Debug.Log("�ȳ礸��");
    }

 
 
}
