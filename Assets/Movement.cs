using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rgPly;
    public SpriteRenderer spriteRenderer; 

    public Animator animator;
    private float playerSpeed;
    private float playerJump;
    private bool isJump;
    private float playMoveHorizontal;
    private float playMoveVertical;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {

        rgPly = gameObject.GetComponent<Rigidbody2D>();


        playerSpeed = 1.0f;
        playerJump = 35.0f;
        isJump = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        playMoveHorizontal = Input.GetAxisRaw("Horizontal");


        playMoveVertical = Input.GetAxisRaw("Vertical");

        if (playMoveHorizontal < 0 && facingRight) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
            facingRight = false;
        }
        else if (playMoveHorizontal > 0 && !facingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            facingRight = true;
        }
    }
    void FixedUpdate()
    {



        if (playMoveHorizontal > 0.1f || playMoveHorizontal < -0.1f) 
        {
            rgPly.AddForce(new Vector2(playMoveHorizontal * playerSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJump && playMoveVertical > 0.1f)
        {
            rgPly.AddForce(new Vector2(0f, playMoveVertical * playerJump), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster") 
        {
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "Gro") 
        {
            isJump = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gro")
        {
            isJump = true;
        }
    }




}

