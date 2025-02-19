using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Talk;
    [SerializeField] private Image image;
    [SerializeField] private GameObject GameObject;
    [SerializeField] private TextMeshPro Flapy;

    private UiManager uiManager;



    private void Awake()
    {

        if(uiManager == null)
        {
            uiManager = this;
            DontDestroyOnLoad(uiManager.gameObject);
        }
        else
        {
            Destroy(uiManager.gameObject);
        }
     
        if (GameObject ==  null)
        {
            GameObject = GameObject.Find("TalkObject");
        }
    }

    private void Start()
    {
        Flapy =FindAnyObjectByType<TextMeshPro>();
        ReaderBoardSet();
    }

    public  void StartCorutine(List<string> strings)
    {
        StartCoroutine(showtext(strings));
    }
    public void SetAct()
    {
        if(gameObject != null)
        GameObject.SetActive(true);
    }
    public void SetFalse()
    {
        if (gameObject != null)
            GameObject.SetActive(false);
    }

    public void SetIma(Sprite sprite)
    {
        if (image != null)
            image.sprite = sprite;
    }

    private IEnumerator showtext(List<string> list)
    {
     
        for (int i = 0; i < list.Count; i++)  
        {
            Talk.text = list[i];
            yield return new WaitForSeconds(1f);
        }
    }


    public void ReaderBoardSet()
    {
        StringBuilder sb = new StringBuilder();
        int number = 1;
        sb.Append("Flapy\n");

        if (GameManager.instance.FlapyList != null)
        {
            foreach (int i in GameManager.instance.FlapyList)
            {
                sb.Append($"{number}. {i.ToString()}\n");
                number++;
                
            }
        }

        Debug.Log("리더보드 업데이트됨: " + sb.ToString());
     
        Flapy.text = sb.ToString();
       

    }

}
