using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoBoundary : MonoBehaviour
{
    public Vector2Variable Boundary;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(Boundary.Value.x* 2, Boundary.Value.y* 2, 1));
    }
}
