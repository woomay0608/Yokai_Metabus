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
           
        }
     
        if (TalkObject ==  null)
        {
            TalkObject = GameObject.Find("TalkObject");
        }
    }

    private void Start()
    {

        
        

  
        
    }

    public  void StartCorutine(List<string> strings)
    {
        StartCoroutine(showtext(strings));
    }
    public void SetAct()
    {
        if(TalkObject != null)
            TalkObject.SetActive(true);
    }
    public void SetFalse()
    {
        if (TalkObject != null)
            TalkObject.SetActive(false);
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
