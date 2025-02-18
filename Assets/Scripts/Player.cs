using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 Inputvetor;
    private bool IsLeft;

    [Range(0f,10f)][SerializeField]private float speed = 5f;

    Rigidbody2D rb;
    SpriteRenderer rbSprite;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputvetor.x = Input.GetAxisRaw("Horizontal");
        Inputvetor.y = Input.GetAxisRaw("Vertical");

        if(Inputvetor.x  == -1)
        {
            IsLeft = true;
        }
        else
        {
            IsLeft = false;
        }
    }

    private void FixedUpdate()
    {
        if(IsLeft)
        {
            rbSprite.flipX = true;
        }
        else
        {
            rbSprite.flipX= false;
        }

        Vector2 moveAmount = Inputvetor.normalized * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + moveAmount);



    }
}
