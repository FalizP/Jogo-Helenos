using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Player_Controls playerControls;

    Vector2 moveDirection = Vector2.zero;
    private InputAction move;

    private void Awake()
    {
        playerControls = new Player_Controls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveCharacter(); 
    }

    private Vector2 moveCharacter()
    {
        moveDirection = move.ReadValue<Vector2>();
        return moveDirection;
    }
}
