using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float moveSpeed = 8f;
    float horizontalMove;

    public bool isJump;

    private bool _canWallJump;
    private bool _canDoubleJump;
    private Vector2 _wallNormal;
    private Vector2 _direction;
    private bool onRoad;

    //死亡
    public void Die()
    {
        moveSpeed=0;
        GetComponent<CapsuleCollider2D>().enabled=false;
        
        GameManager.Instance.DelayReset(1f);
    }
    public void Next()
    {
        GameManager.Instance.NextLevel();
    }
    //碰撞
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if(other.CompareTag("DeathArea"))
    //     {
    //         Die();
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "DeathArea"){
            Die();
        }
        else if(other.collider.tag == "NextWorldArea")
        {
            Next();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
            animator.SetBool("isMove",true);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal")  * moveSpeed;
            animator.SetBool("isMove",true);
        }
        else
        {
            horizontalMove = 0;
            animator.SetBool("isMove", false);
        }
        //跳躍
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
            onRoad=false;
        }
        animator.SetBool("isJump", isJump);

        //蹬牆跳
        /*if(!controller.enable)
            return;*/
        float horInput=Input.GetAxis("Horizontal");
        if(onRoad)
        {
            _canWallJump=false;
            _direction=new Vector2(horInput, 0);
            //_velocity=_direction*moveSpeed;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //_gravImpulse=_jumpHeight;
                _canDoubleJump=true;
            }
        }
        else
        {
            //_gravImpulse-=_gravity;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_canWallJump)
                {
                    //_gravImpulse=_jumpHeight;
                    //_velocity=_wallNormal*moveSpeed;
                    _canWallJump=false;
                    _canDoubleJump=false;
                }
                else if(_canDoubleJump)
                {
                    //_gravImpulse+=_jumpHeight;
                    _canDoubleJump=false;
                }
            }
        }
        //_velocity.y=_gravImpulse;
        //controller.Move(_velocity * Time.deltaTime);
    }
        //落地判定
    public void Onland()
    {
        isJump = false;
        onRoad=true;
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, isJump);
    }
    //蹬牆跳判定
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!onRoad && hit.collider.CompareTag("Wall"))
        {
            _wallNormal=hit.normal;
            _canWallJump=true;
        }
    }
}