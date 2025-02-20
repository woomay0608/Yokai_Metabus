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
    [SerializeField] private GameObject Accessory;

    [SerializeField] private Image Image;

    [SerializeField] private Button[] Buttons = new Button[6];
    [SerializeField] private Accessorry[] Accessors = new Accessorry[6];
    [SerializeField] private Image[] Accessorys = new Image[6];
    public bool[] IsFind = new bool[6];



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
        if(i == 3 && Accessory != null)
             Accessory.SetActive(true);
    }
    public void SetFalse(int i)
    {
        if (TalkObject != null && i == 1)
            TalkObject.SetActive(false);
        if (i == 2 && ColorObject != null)
            ColorObject.SetActive(false);
        if (i == 3 && Accessory != null)
            Accessory.SetActive(false);
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

    public void ShowAcces()
    {
        for(int i = 0; i< Accessorys.Length; i++) 
        {
            if (IsFind[i] == true)
            {
                
                Buttons[i].gameObject.SetActive(true);
                Buttons[i].onClick.AddListener(Accessors[i].Equip);
                Accessorys[i].gameObject.SetActive(true);

            }
        }
    }
}
