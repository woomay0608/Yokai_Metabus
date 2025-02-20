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
    public Sprite sprite;

    List<string> talk = new List<string>();

    public bool IsColliding = false;
    private bool IsMini =false;
    private bool IsColor = false;
    private bool IsDice = false;

    UiManager uiManager;
    // Start is called before the first frame update

    private void Awake()
    {
        uiManager = FindAnyObjectByType<UiManager>();
    }
    void Start()
    {
        
    }
    //


    private void Update()
    {
        if(IsColliding && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("nurum");
            //uiManager.SetIma(sprite);
            
            
            
            if (this.FriendId == 1)
            {
                if(uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                IsMini = true;
                IsColor = false;
                IsDice = false;
                uiManager.ImageChange(0);
                uiManager.SetAct(1);
                uiManager.StartCorutine(talk);
            }
            if (this.FriendId == 2)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                IsMini = false;
                IsColor = true;
                IsDice = false;
                uiManager.ImageChange(1);
                uiManager.SetAct(1);
                uiManager.StartCorutine(talk);
            }
            if (this.FriendId == 3)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                IsMini = false;
                IsColor = false;
                IsDice = true;
                uiManager.ImageChange(2);
                uiManager.SetAct(1);
                uiManager.StartCorutine(talk);
            }


        }
        if(IsColliding && IsMini && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MiniGame");
        }
        if(IsColliding&& IsColor && Input.GetKeyDown(KeyCode.E))
        {
            uiManager.SetAct(2);
        }
        if (IsColliding && IsDice && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MiniGame2");
        }

    }

    //충돌을 감지해주는 메소드
    //Collistion/ Trigger
    //enter , stay, Exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talkText.gameObject.SetActive(false);
            uiManager.SetFalse(1);
            uiManager.SetFalse(2);
            IsColliding = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsColliding = true;
            talkText.gameObject.SetActive(true);
            Debug.Log("안녕");

            SetText();
        }
 
    }
 


    private void SetText()
    {
        if(this.FriendId ==1)
        {
            talk.Add("Hi");
            talk.Add("You want to play FlappyGame?");
            talk.Add("if your answer is \"yes\" push \"E\"");
        }
        else if(this.FriendId == 2) 
        {
            talk.RemoveRange(0,talk.Count);
            talk.Add("so cold");
            talk.Add("You want to Change Your Color?");
            talk.Add("if your answer is \"yes\" push \"E\"");
        }
        else if(this.FriendId == 3) 
        {
            talk.RemoveRange(0, talk.Count);
            talk.Add("Do you like Gamble?");
            talk.Add("if You want to play OddAndEvenDice");
            talk.Add("push \"E\" and then take you to there");
        }
    }


 
}
