using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Talk;
    [SerializeField] private Image image;
    [SerializeField] private GameObject GameObject;

    private UiManager uiManager;



    private void Awake()
    {
        if(GameObject ==  null)
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
        GameObject.SetActive(true);
    }
    public void SetFalse()
    {
        GameObject.SetActive(false);
    }

    public void SetIma(Sprite sprite)
    {
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
