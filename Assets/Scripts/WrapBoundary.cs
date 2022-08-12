using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBoundary : MonoBehaviour
{
    private Transform trans;

    public Vector2Variable Boundary;
    public bool isOutside = true;
    private void Awake()
    {
        trans = GetComponent<Transform>();
    }
    private void Update()
    {
        WrapAround();
    }

    void WrapAround()
    {
        float x = trans.position.x;
        float y = trans.position.y;


        if(x < Boundary.Value.x && x > -Boundary.Value.x && y < Boundary.Value.y && y > -Boundary.Value.y)
        {
            isOutside = false;
        }


        if(!isOutside)
        {
            if (x > Boundary.Value.x)
            {
                x = -Boundary.Value.x+1;
            }
            else if (x < -Boundary.Value.x)
            {
                x = Boundary.Value.x-1;
            }

            if (y > Boundary.Value.y)
            {
                y = -Boundary.Value.y+1;
            }
            else if (y < -Boundary.Value.y)
            {
                y = Boundary.Value.y-1;
            }
        }


        trans.position = new Vector2(x, y);
    }
}
