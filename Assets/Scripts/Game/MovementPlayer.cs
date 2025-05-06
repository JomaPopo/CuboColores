using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : Player
{
    Rigidbody2D _compRigidbody;
    public int speed;
    public float jumpforce = 5f;
    public float direction;
    public LayerMask layermask;
    public bool grounded;
    public bool doublejump;

    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FijarseSuelo();
    }

    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(direction * speed, _compRigidbody.velocity.y);
    }

  
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        direction = movement.x; 
    }

    public void jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (grounded)
            {
                _compRigidbody.velocity = new Vector2(_compRigidbody.velocity.x, jumpforce);
            }
            else if (doublejump)
            {
                _compRigidbody.velocity = new Vector2(_compRigidbody.velocity.x, jumpforce);
                doublejump = false;
            }
        }
    }

    private void FijarseSuelo()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1f, layermask))
        {
            grounded = true;
            if (!doublejump)
            {
                doublejump = true;
            }
        }
        else
        {
            grounded = false;
        }
    }
}
