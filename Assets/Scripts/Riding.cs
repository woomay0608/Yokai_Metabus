using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riding : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer SpriteRenderer;
    public Animator animator;
    [SerializeField] private Player player;
    [SerializeField] private Sprite Ridingone;
    [SerializeField] private Sprite RidingTwo;
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

    public void RidingOneOn()
    {
        SpriteRenderer.sprite = Ridingone;
        animator.SetBool("IsKitsu",true );
        player.speed += 3f;
    }
    public void RidingTwoon()
    {
        SpriteRenderer.sprite = RidingTwo;
        animator.SetBool("IsKitus", true);
        player.speed += 3f;
    }


}
