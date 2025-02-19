using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tong : MonoBehaviour
{

    private Animator m_Animator;

    private Coroutine mixCoroutine;

    bool m_IsPlaying = false;
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
        if (!m_IsPlaying)
         StartCoroutine(Mix());
    }
    private IEnumerator Mix()
    {
        yield return new WaitForSeconds(0.1f);
        m_Animator.SetTrigger("IsStart");
        m_IsPlaying =true;


    }
}
