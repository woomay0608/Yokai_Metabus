using System;
using System.Collections;
using System.Collections.Generic;

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

    private UiManager uiManager;



    private void Awake()
    {

        if(uiManager == null)
        {
            uiManager = this;
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


}
