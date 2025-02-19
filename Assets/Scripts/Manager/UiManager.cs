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
    
    [SerializeField] private GameObject TalkObject;
    [SerializeField] private GameObject ColorObject;
    [SerializeField] private Image Image;
    public static UiManager Instace;

    public friends[] friends = new friends[2];

    private void Awake()
    {

        if(Instace == null)
        {
            Instace = this;
            DontDestroyOnLoad(Instace);
        }
        else
        {
            Destroy(Instace.gameObject);
            return;
        }
     
        if (TalkObject ==  null)
        {
            TalkObject = GameObject.Find("TalkObject");
        }
        if (ColorObject == null)
        {
            ColorObject = GameObject.Find("ColorChange");
        }
    }

    private void Start()
    {
    }

    public  void StartCorutine(List<string> strings)
    {
        StartCoroutine(showtext(strings));
    }
    public void SetAct(int i)
    {
        if(TalkObject != null && i == 1)
            TalkObject.SetActive(true);
        if(i == 2 && ColorObject != null)
            ColorObject.SetActive(true);
    }
    public void SetFalse(int i)
    {
        if (TalkObject != null && i == 1)
            TalkObject.SetActive(false);
        if (i == 2 && ColorObject != null)
            ColorObject.SetActive(false);
    }


    private IEnumerator showtext(List<string> list)
    {
     
        for (int i = 0; i < list.Count; i++)  
        {
            Talk.text = list[i];
            yield return new WaitForSeconds(1f);
        }
    }

    public void ImageChange(int i)
    {
        Image.sprite = friends[i].sprite;
    }


}
