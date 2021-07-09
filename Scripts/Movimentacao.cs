using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    // Variaveis gerais
    public float runSpeed;

    Rigidbody2D body;
    Animator anim;
    private float horizontal, vertical;
    private bool adireita;

    //inicio do jogo
    void Start ()
    {
        //definir variaveis da Unity
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (runSpeed == 0) runSpeed = 15; //velocidade padrão
    }

    void FixedUpdate()
    {
        //mover
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        //joysticks
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //animações 
        anim.SetFloat("x", horizontal);
        anim.SetFloat("y", vertical);

        //define lado
        if (transform.localScale.x > 0) adireita = true; else adireita = false;

        //giro
        if ((horizontal != 0) && (horizontal > 0 && !adireita || horizontal < 0 && adireita)) //vira
        {
            transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }
    }
}