using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float Speed = 5f;
    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    void Update()
    {

        float moveInput = Input.GetAxis(movementAxisName);

        //Calcula a nova posi��o da raquete baseada na entrada e na velocidade 
        Vector3 newPosition = transform.position + Vector3.up * moveInput * Speed * Time.deltaTime;

        // Limita a posi��o vertical da raquete para que ela n�o saia da tela
         newPosition.y = Mathf.Clamp(newPosition.y, -4.1f, 4.1f);

        // Atualiza a posi��o da raquete
        transform.position = newPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SavedController.Instance.colorPlayer;
        else
            spriteRenderer.color = SavedController.Instance.colorEnemy;
    }
}
