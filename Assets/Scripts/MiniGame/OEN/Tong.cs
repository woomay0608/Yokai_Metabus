using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tong : MonoBehaviour
{

    private Animator m_Animator;

    private Coroutine mixCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCor() //나중에 게임매니저에서 실행
    {
     
         StartCoroutine(Mix());
    }
    private IEnumerator Mix()
    {
        yield return new WaitForSeconds(0.1f);
        m_Animator.SetTrigger("IsStart");
      


    }
}
