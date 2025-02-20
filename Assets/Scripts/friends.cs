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

    [SerializeField] private Button Yes;
    [SerializeField] private Button No;


    public bool IsColliding = false;


    UiManager uiManager;
    // Start is called before the first frame update

    private void Awake()
    {
        uiManager = FindAnyObjectByType<UiManager>();
    }
    void Start()
    {
        No.onClick.AddListener(uiManager.SetFalse);
    }
    //


    private void Update()
    {
        if (IsColliding && Input.GetKeyDown(KeyCode.F))
        {
            if (this.FriendId == 1)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                Yes.onClick.RemoveAllListeners();

                Yes.onClick.AddListener(Flappy);
                uiManager.ImageChange(0);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);
            }
            if (this.FriendId == 2)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                Yes.onClick.RemoveAllListeners();
                Yes.onClick.AddListener(uiManager.SetColor);
                uiManager.ImageChange(1);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);
            }
            if (this.FriendId == 3)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                Yes.onClick.RemoveAllListeners();
                Yes.onClick.AddListener(Dice);
                uiManager.ImageChange(2);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);
            }
            if (this.FriendId == 4)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                Yes.onClick.RemoveAllListeners();
                Yes.onClick.AddListener(uiManager.SetAcce);
                uiManager.ImageChange(3);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);
            }

            if(this.FriendId == 5)
            {
                if (uiManager == null)
                {
                    Debug.Log("널임");
                    uiManager = FindAnyObjectByType<UiManager>();
                }
                Yes.onClick.RemoveAllListeners();
                Yes.onClick.AddListener(uiManager.SetRide);
                uiManager.ImageChange(4);
                uiManager.SetAct();
                uiManager.StartCorutine(talk);

            }


        }

    }

    private void Flappy()
    {
        SceneManager.LoadScene("MiniGame");
    }
    private void Dice()
    {
        SceneManager.LoadScene("MiniGame2");
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
            uiManager.DownAcce();
            uiManager.DownColor();
            uiManager.DownRide();
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
        if (this.FriendId == 1)
        {
            talk.Add("Hi");
            talk.Add("You want to play FlappyGame?");
           
        }
        else if (this.FriendId == 2)
        {
            talk.RemoveRange(0, talk.Count);
            talk.Add("so cold");
            talk.Add("You want to Change Your Color?");
            
        }
        else if (this.FriendId == 3)
        {
            talk.RemoveRange(0, talk.Count);
            talk.Add("Do you like Gamble?");
            talk.Add("if You want to play OddAndEvenDice");
            
        }
        else if (this.FriendId == 4)
        {
            talk.RemoveRange(0, talk.Count);
            talk.Add("If you've found an accessory, talk to me");
            talk.Add("I can help you put it on");
            
        }
        else if (this.FriendId == 5)
        {
            talk.RemoveRange(0, talk.Count);
            talk.Add("If you ever get a high score in a minigame, let me come.");
            talk.Add("Let me show you something you can ride.");

        }
    }



}
