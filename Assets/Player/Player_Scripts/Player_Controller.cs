using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    enum Estados
    {
        Idle_Lado,
        Idle_Frente,
        Idle_Tras,
        Walking_Left,
        Walking_Right,
        Walking_Up,
        Walking_Down
    }
    Estados estadoAtual = new();

    SpriteRenderer spriteRenderer;
    public PlayerAnimationController playerAnimation;
    private Vector2 moveDirection = Vector2.zero;

    private InputAction move;

    [SerializeField] private float speed = 25;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    float input_x, input_y;

    private void FixedUpdate()
    {
        MoveCharacter();

    }

    private void MoveCharacter()
    {
        if (DialogueManager.GetInstance().DialogueIsPlaying)
        { return; };

        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");

        var move = new Vector3(input_x, input_y, 0).normalized;
        transform.position += move * speed * Time.deltaTime;

        DefineEstadoAtual();
        DefineAnimacao();
    }

    void DefineEstadoAtual()
    {
        Vector2 eixo = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            estadoAtual = Estados.Walking_Left;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            estadoAtual = Estados.Walking_Right;
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") == 0 && (estadoAtual == Estados.Walking_Left || estadoAtual == Estados.Walking_Right))
            {
                estadoAtual = Estados.Idle_Lado;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            estadoAtual = Estados.Walking_Up;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            estadoAtual = Estados.Walking_Down;
        }
        else
        {
            if (eixo.x == 0 && (estadoAtual == Estados.Walking_Up || estadoAtual == Estados.Walking_Down))
            {
                estadoAtual = Estados.Idle_Frente;
            }/*
            if (eixos.x == 0 && estadoAtual == Estados.Walking_Up)
            {
                estadoAtual = Estados.Idle_Tras;
            }*/

        }
    }

    void DefineAnimacao()
    {
        switch (estadoAtual)
        {
            case Estados.Idle_Lado:
                playerAnimation.PlayAnimation("Player_Idle_Lado");
                break;

            case Estados.Idle_Frente:
                playerAnimation.PlayAnimation("Player_Idle_Frente");
                break;

            case Estados.Walking_Left:
                playerAnimation.PlayAnimation("Player_Walking");
                spriteRenderer.flipX = false;
                break;

            case Estados.Walking_Right:
                playerAnimation.PlayAnimation("Player_Walking");
                spriteRenderer.flipX = true;
                break;

            case Estados.Walking_Up:
                playerAnimation.PlayAnimation("Player_Walking_Up");
                break;

            case Estados.Walking_Down:
                playerAnimation.PlayAnimation("Player_Walking_Down");
                break;
        }
    }
}
