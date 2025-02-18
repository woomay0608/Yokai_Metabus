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


    //충돌을 감지해주는 메소드
    //Collistion/ Trigger
    //enter , stay, Exit

    private void OnCollisionEnter2D(Collision2D collision)
    {
        talkText.gameObject.SetActive(true);
        Debug.Log("안녕");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        talkText.gameObject.SetActive(false);
        Debug.Log("안녕ㅈㅈ");
    }

 
 
}
