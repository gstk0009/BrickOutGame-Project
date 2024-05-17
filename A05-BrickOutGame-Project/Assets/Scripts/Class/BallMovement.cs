using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public CircleCollider2D cc2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    

    // Update is called once per frame
    void Update()
    {
        Bounce();
    }

    private void Bounce()
    {
        
    }
}
