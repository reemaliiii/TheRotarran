using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    //CharacterController con;
    Rigidbody2D rb;

    void Start()
    {
        //con = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 mov;
        mov.x = Input.GetAxis("Horizontal");
        mov.y = Input.GetAxis("Vertical");
        mov.Normalize();

        mov *= Time.deltaTime * Speed;

        rb.MovePosition(rb.position + mov);
        //con.Move(mov);
    }
}
