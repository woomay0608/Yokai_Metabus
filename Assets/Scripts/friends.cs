using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class friends : MonoBehaviour
{


    [SerializeField] private int FriendId;
    [SerializeField] private TMP_Text talkText;
    [SerializeField] private Sprite Face;

    List<string> talk = new List<string>();

    private bool IsColliding = false;
    private bool IsMini =false;
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
            uiManager.SetAct();
            uiManager.SetIma(Face);
            uiManager.StartCorutine(talk);
            IsMini = true;

        }
        if(IsMini && Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("MiniGame");
        }
    }

    //충돌을 감지해주는 메소드
    //Collistion/ Trigger
    //enter , stay, Exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        talkText.gameObject.SetActive(false);
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
        if (FriendId ==1)
        {
            talk.Add("Kainin nim");
            talk.Add("han panheayo");
        }
    }


 
}
