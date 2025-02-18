using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapyPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    Animator Anime;
    Rigidbody2D _Rigid;

    public float FlapForce = 6f; //점프
    public float ForwardForce = 3f; //앞으로 나가는 힘
    public bool IsDead = false;
    float DeathCount = 0f; //죽은 뒤 몇 초 후에 바꿔줄 것이냐

    bool IsFalp = false; //점프함?

    public bool GodMode = false; //디버깅용


    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;

        Anime = GetComponentInChildren<Animator>();
        _Rigid = GetComponent<Rigidbody2D>();


        if (Anime == null)
            Debug.LogError("애니메이터 없다");

        if (_Rigid == null)
            Debug.LogError("리지드바디 없다");

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            if (DeathCount <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                DeathCount -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                IsFalp = true;
            }
        }


    }
    private void FixedUpdate()
    {
        if (IsDead) return;

        Vector3 velocity = _Rigid.velocity; //값이 복사가 된 것
        velocity.x = ForwardForce;

        if (IsFalp)
        {
            velocity.y += FlapForce;
            IsFalp = false;
        }

        _Rigid.velocity = velocity;

        float angle = Mathf.Clamp((_Rigid.velocity.y * 10f), -90f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GodMode) return;
        if (IsDead) return;

        IsDead = true;
        DeathCount = 1f;

        Anime.SetInteger("IsDie", 1);
        gameManager.Gameover();
    }

}
