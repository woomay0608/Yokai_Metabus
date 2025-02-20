using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 Inputvetor;
    private bool IsLeft;
    private bool IsRight;

    [Range(0f,10f)][SerializeField]private float speed = 5f;

 

    Rigidbody2D rb;
    public SpriteRenderer rbSprite;
   
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputvetor.x = Input.GetAxisRaw("Horizontal");
        Inputvetor.y = Input.GetAxisRaw("Vertical");

        if(Inputvetor.x  == -1)
        {
            IsLeft = true;
            IsRight = false;
        }
        if(Inputvetor.x == 1)
        {
            IsRight = true;
            IsLeft = false;
        }

    }

    private void FixedUpdate()
    {
        if(IsLeft){rbSprite.flipX = true;}
        if (IsRight) { rbSprite.flipX=false;}
        animator.SetBool("IsMove", Inputvetor.magnitude > 0);


        Vector2 moveAmount = Inputvetor.normalized * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveAmount);



    }
}
