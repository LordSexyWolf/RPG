using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //Define to Inspector the variable
    [SerializeField] private float velocity;
    //propety
    public Vector2 MovementDirection => _movementDirection;
    //If I need to modify the variable in other class: public float Velocity => velocity;
    public bool InMovement => _movementDirection.magnitude > 0f;
    //Reference to Ridbody to GameObject
    private Rigidbody2D _rigidbody2D;
    private Vector2 _input;
    private Vector2 _movementDirection;

    private void Awake() 
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(x:Input.GetAxisRaw("Horizontal"), y:Input.GetAxisRaw("Vertical"));

        //x
        if(_input.x > 0.1f)
        {
            _movementDirection.x = 1f;
        }else if(_input.x < 0f)
        {
            _movementDirection.x = -1;
        }else{
            _movementDirection.x = 0;
        }
        //y
        if(_input.y > 0.1f)
        {
            _movementDirection.y = 1f;
        }else if(_input.y < 0f)
        {
            _movementDirection.y = -1;
        }else{
            _movementDirection.y = 0;
        }
    }
    //Moviment velocity 
    private void FixedUpdate() 
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movementDirection * velocity * Time.fixedDeltaTime);
    }
}
