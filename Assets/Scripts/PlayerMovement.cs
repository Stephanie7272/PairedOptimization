using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float jump = 14f;
    [SerializeField] private LayerMask ground;
    private enum MovementState { Idle, Walk, Jump, Fall}

    public GameObject winScreen;
    public TextMeshProUGUI winText;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }


    private void FixedUpdate()
    {
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.Walk;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.Walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.Idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.Jump;    
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGround()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }

}
