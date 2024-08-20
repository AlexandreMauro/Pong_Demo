using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public float VelUp = 0.9f;

   public Rigidbody2D rb;

    public float speed = 3f;

    public GameObject ball;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); ball = GameObject.Find("Ball"); // Encontra o objeto da bola na cena    }
    }

    void Update()
    {
        /*if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, -4.1f, 4.1f); // Limita a posição Y
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); // Move gradualmente para a posição Y da bola        }    }

        }*/

        
    }
}

