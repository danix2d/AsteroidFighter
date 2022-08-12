using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveTO : MonoBehaviour
{
    public float time;
    public Vector3 scale;
    public Ease ease;
    public void MoveToPos()
    {
        Transform trans = GetComponent<RectTransform>();
        trans.DOScaleY(scale.y, time);
        trans.DOScaleX(scale.x, time);
    }
}
