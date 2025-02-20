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
    [Header("Talk Ui")]
    [SerializeField] private TextMeshProUGUI Talk;  
    [SerializeField] private GameObject TalkObject;
    [Header("Color")]
    [SerializeField] private GameObject ColorObject;
    [SerializeField] private Image Image;

    [Header("Accessorry")]
    [SerializeField] private GameObject Accessory;
    [SerializeField] private Button[] Buttons = new Button[6];
    [SerializeField] private Accessorry[] Accessors = new Accessorry[6];
    [SerializeField] private Image[] Accessorys = new Image[6];
    public bool[] IsFind = new bool[6];
    [Header("Riding")]
    [SerializeField] private Riding rind;
    [SerializeField] private Image RidingOne;
    [SerializeField] private Image RidingTwo;
    [SerializeField] private Button RidingOnee;
    [SerializeField] private Button RidingTwoe;




    public static UiManager Instace;

    public friends[] friends = new friends[5];

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
        ShowRiding();
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
    public void SetColor()
    {
        if(ColorObject != null)
        {
            ColorObject.SetActive(true);
        }
    }
    public void DownColor()
    {
        if(ColorObject != null)
        {
            ColorObject.SetActive(false );
        }
    }
    public void SetAcce()
    {
        if (Accessory != null)
        {
            Accessory.SetActive(true);
        }
    }
    public void DownAcce()
    {
        if (Accessory != null)
        {
            Accessory.SetActive(false);
        }
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
                Buttons[i].onClick.RemoveAllListeners();

                Buttons[i].gameObject.SetActive(true);
                Buttons[i].onClick.AddListener(Accessors[i].Equip);
                Accessorys[i].gameObject.SetActive(true);

            }
        }
    }

    public void ShowRiding()
    {
        if(GameManager.instance.IsRidingOne)
        {
            RidingOne.color = new Color(1f, 1f, 1f);
            RidingOnee.onClick.AddListener(rind.RidingOneOn);
           RidingOnee.gameObject.SetActive(true);
        }
        if (GameManager.instance.IsRidingTwo)
        {
            RidingTwo.color = new Color(1f, 1f, 1f);
            RidingOnee.onClick.AddListener(rind.RidingTwoon);
            RidingOnee.gameObject.SetActive(false);
        }
    }
}
