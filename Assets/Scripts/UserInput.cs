using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public Vector2 UInput
    {
        get
        {
            return _input;
        }
        private set
        {
            _input = value;
        }
    }

    public bool Shoot
    {
        get
        {
            return _shoot;
        }
        private set
        {
            _shoot = value;
        }
    }

    private Vector2 _input;
    private bool _shoot;

    private float x;
    private float y;
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        _input.x = x;
        _input.y = y > 0 ? y : 0;

        _shoot = Input.GetKeyDown(KeyCode.Space) ? true : false;
    }
}
