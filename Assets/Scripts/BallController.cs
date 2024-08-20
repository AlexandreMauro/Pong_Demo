using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public float velUp = 1.1f;
    public Rigidbody2D rb;
    public Vector2 StartingVel = new Vector2(5f, 5f);
    public GameManager GameManager;


    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) GetComponent<Rigidbody2D>();
        rb.velocity = StartingVel;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Vector2 NewVelocity = rb.velocity;

            NewVelocity.y = -NewVelocity.y;
            rb.velocity = NewVelocity;
        }

        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy"))
        {

            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= velUp;
        } 
        

        if (collision.gameObject.CompareTag("WallPlayer"))
        {
            GameManager.ScorePlayer();
            ResetBall();
           
        }else if (collision.gameObject.CompareTag("WallEnemy"))
        {
            GameManager.ScoreEnemy();
            ResetBall();

        }
    }
}
