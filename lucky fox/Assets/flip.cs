using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{

    SpriteRenderer sprite;
    bool faceRight = true;

    public GameObject bulletPrefab;
    GameObject bullet;

    public float bulletspeed;
    

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }

    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && faceRight)
        {
            //shooting code here
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed, 0f);
            Destroy(bullet, 1f);
        }
        else if(Input.GetMouseButtonDown(0) && !faceRight)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletspeed, 0f);
            Destroy(bullet, 1f);
        }
    }

}
