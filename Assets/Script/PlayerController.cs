using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public InputAction MoveAction;
    Vector2 move;

    private Animator _animator;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        
        move = MoveAction.ReadValue<Vector2>();
        _animator.SetFloat(_horizontal, move.x);
        _animator.SetFloat(_vertical, move.y);
        if (move != Vector2.zero) {
            _animator.SetFloat(_lastHorizontal, move.x);
            _animator.SetFloat(_lastVertical, move.y);
        }
       


    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
