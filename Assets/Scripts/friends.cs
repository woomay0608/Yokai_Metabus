using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class friends : MonoBehaviour
{


    [SerializeField] private int FriendId;
    [SerializeField] private TMP_Text talkText;
    [SerializeField] private Sprite sprite;

    List<string> talk = new List<string>();

    private bool IsColliding = false;
    private bool IsMini =false;
    private bool IsColor = false;

    UiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindAnyObjectByType<UiManager>();
        talkText.gameObject.SetActive(false);
    }
    //


    private void Update()
    {
        if(IsColliding && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("nurum");
            uiManager.SetIma(sprite);
            uiManager.SetAct();
            
            uiManager.StartCorutine(talk);
            if(this.FriendId == 1)
            IsMini = true;
            if(this.FriendId == 2)
            IsColor = true;


        }
        if(IsMini && Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("MiniGame");
        }
        if(IsColor && Input.GetKeyDown(KeyCode.S))
        {

        }
    }

    //충돌을 감지해주는 메소드
    //Collistion/ Trigger
    //enter , stay, Exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        talkText.gameObject.SetActive(false);
        uiManager.SetFalse();
        IsColliding = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsColliding = true;
        talkText.gameObject.SetActive(true);
        Debug.Log("안녕");

        SetText();
 
    }
 


    private void SetText()
    {
        if(this.FriendId ==1)
        {
            talk.Add("Hi");
            talk.Add("You want to play FlapyGame?");
            talk.Add("if your answer is \"yes\" push \"S\"");
        }
        else if(this.FriendId == 2) 
        {
            talk.RemoveRange(0,talk.Count);
            talk.Add("so cold");
            talk.Add("You want to Change Your Color?");
            talk.Add("if your answer is \"yes\" push \"S\"");
        }
    }


 
}
