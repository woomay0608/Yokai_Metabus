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
                }
                IsMini = true;
                IsColor = false;
                uiManager.ImageChange(0);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);
            }
            if (this.FriendId == 2)
            {
                IsMini = false;
                IsColor = true;
                uiManager.ImageChange(1);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);
            }


        }
        if(IsColliding && IsMini && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MiniGame");
        }
        if(IsColliding&& IsColor && Input.GetKeyDown(KeyCode.E))
        {

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
            uiManager.SetFalse();
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
    }


 
}
