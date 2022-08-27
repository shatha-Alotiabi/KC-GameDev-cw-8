using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class octoScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Transform groundCheck;
    public LayerMask ground;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        rb.velocity = new Vector2(speed, 0);
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        if (!isGrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           SceneManager.LoadScene(0);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
