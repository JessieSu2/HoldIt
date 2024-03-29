using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    public float speed = 7f;
    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        sprite = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        if (dirX != 0)
        {
            GetComponent<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", false);
        }
        rb.velocity= new Vector2(dirX * speed, rb.velocity.y);
        Flip();
    }

    private void Flip()
    {
        if (dirX < 0f)
        {
            sprite.flipX= false;
        }
        else if (dirX > 0f)
        {
            sprite.flipX = true;
        }
        

    }
}
