using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riding : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer SpriteRenderer;
    public Animator animator;
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
