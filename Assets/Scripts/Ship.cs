using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private UserInput UserInput;
    private Rigidbody2D rigid;

    public ParticleSystem LThruster;
    public ParticleSystem RThruster;
    private ParticleSystem.MainModule main;

    public float moveForce;
    public float torqueForce;

    void Awake()
    {
        UserInput = GetComponent<UserInput>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rigid.AddForce(transform.up * moveForce * UserInput.UInput.y);
        rigid.AddTorque(-torqueForce * UserInput.UInput.x);

        main = LThruster.main;
        main.startSpeed = UserInput.UInput.y * 3 + 0.5f;

        main = RThruster.main;
        main.startSpeed = UserInput.UInput.y * 3 + 0.5f;
    }
}   
