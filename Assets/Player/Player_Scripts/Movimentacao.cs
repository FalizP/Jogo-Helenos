using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 moveDirection = Vector2.zero;
    private PlayerControls playerControls;
    private InputAction move;
    private InputAction interacting;

    private bool isJumping = false;
    private bool isInteracting = false;
    public float speed = 5f;

    #region Inventário
    private List<string> keys = new List<string>();
    #endregion

    #region Funções de Inicialização
    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        interacting = playerControls.Player.Interacting;
        interacting.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        interacting.Disable();
    }
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = MoveCharacter();
    }

    private Vector2 MoveCharacter()
    {
        moveDirection = (move.ReadValue<Vector2>()) * speed;
        return moveDirection;
    }

    private bool InteractingWithDoorLogic()
    {
        isInteracting = interacting.IsPressed();
        return isInteracting;
    }

    #region Detecção de Colisões
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            move.Disable();
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            InteractingWithDoorLogic();
        }

        if (collision.gameObject.CompareTag("DoorWithKey"))
        {
            string doorKey;
            if (collision.gameObject.TryGetComponent(out doorKey))
            {
                if (keys.Contains(doorKey))
                {
                    InteractingWithDoorLogic();
                }
                else
                {
                    return;
                }
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            move.Enable();
        }
    }
    #endregion
}
