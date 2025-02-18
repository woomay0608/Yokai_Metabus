using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class friends : MonoBehaviour
{


    [SerializeField] private int FriendId;
    [SerializeField] private TMP_Text talkText;
    [SerializeField] private Sprite Face;

    List<string> talk = new List<string>();


    UiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindAnyObjectByType<UiManager>();
    }
    //


    //충돌을 감지해주는 메소드
    //Collistion/ Trigger
    //enter , stay, Exit

    private void OnCollisionStay2D(Collision2D collision)
    {
        talkText.gameObject.SetActive(true);
        Debug.Log("안녕");

        SetText();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("nurum");
            uiManager.SetAct();
            uiManager.SetIma(Face);
            uiManager.StartCorutine(talk);

        }
    }
 

    private void OnCollisionExit2D(Collision2D collision)
    {
        talkText.gameObject.SetActive(false);
        uiManager.SetFalse();
        Debug.Log("안녕ㅈㅈ");
    }


    private void SetText()
    {
        if (FriendId ==1)
        {
            talk.Add("Kainin nim");
            talk.Add("han panheayo");
        }
    }


 
}
