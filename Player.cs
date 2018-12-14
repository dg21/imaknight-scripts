using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpspeed;
    public Rigidbody2D rb;
    public string moveleft;
    public string moveright;
    public int life;
    public bool facingRight = true;
    public bool isGrounded = true;
    public bool Attack;
    public bool hurtground;
    Animator anim;
    public int maxHealth;
    public Vector3 spawn;
    public RectTransform healthBar;
    private Transform currentPlateform;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Attack = false;
    }

      

    void Update() {
        float h = Input.GetAxis("Horizontal");
        anim.SetBool("Attack", Attack);

        

        /*if (life == 0)
        {
            transform.position = spawn;
            life = maxHealth;
        }
        */
        if (h < 0)
        {
            transform.Translate(new Vector2(Time.deltaTime * -speed, 0));
            if(facingRight)
                Flip();
        }
        else if (h > 0)
        {
            transform.Translate(new Vector2(Time.deltaTime * speed, 0));
            if (!facingRight)
                Flip();
        }

        anim.SetFloat("speed",Mathf.Abs(h));

        if  (Input.GetButtonDown("Jump")&& isGrounded) 
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }

        anim.SetBool("jump", !isGrounded);
        
        if (Input.GetButtonDown("Fire2"))
        {
            Attack = true;
            
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Attack = false;
        }

        if (Attack  == true && anim.GetCurrentAnimatorStateInfo(0).IsName("attacking")) { 
          
            {
                anim.SetTrigger("Attacking");
           }
        }

      
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
              

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "ground")
        {
            currentPlateform = other.transform;
            transform.parent = currentPlateform;

        }

    }

public void TakeDamage(int damage)
    {
        life = life - damage;
        if (life < 0)
        {
            life = 0;
        }
        if(life == 0)
        {
            transform.position = spawn;
            life = maxHealth;
        }
    }
    
              

        
    

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 newscale = transform.localScale;
        newscale.x *= -1;
        transform.localScale = newscale;

    }

   




}

    



        



 