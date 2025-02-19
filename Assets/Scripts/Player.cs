using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;
    private Vector2 Inputvetor;
    private bool IsLeft;
    private bool IsRight;


    [SerializeField] private Pivot Pivots;
    [SerializeField] private Riding riding;
    [Range(0f,10f)][SerializeField]public float speed = 5f;

 

    Rigidbody2D rb;
    public SpriteRenderer rbSprite;
   
    Animator animator;

    private void Awake()
    {

      
  
    }

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
            Pivots.Sprite.flipX = true;
            Pivots.transform.position =transform.position + new Vector3(0.3f,0.3f,0f);
            riding.SpriteRenderer.flipX = false;
            IsLeft = true;
            IsRight = false;
        }
        if(Inputvetor.x == 1)
        {
            Pivots.Sprite.flipX = false;
            riding.SpriteRenderer.flipX = true;
            Pivots.transform.position = transform.position + new Vector3(-0.3f, 0.3f, 0f);
            IsRight = true;
            IsLeft = false;
        }

    }

    private void FixedUpdate()
    {
        if(IsLeft){rbSprite.flipX = true;}
        if (IsRight) { rbSprite.flipX=false;}
        animator.SetBool("IsMove", Inputvetor.magnitude > 0);
        riding.animator.SetBool("IsMove", Inputvetor.magnitude > 0);


        Vector2 moveAmount = Inputvetor.normalized * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveAmount);



    }
}
