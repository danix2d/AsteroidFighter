using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LoopBubble : MonoBehaviour
{
    public float duration = 1f;
    public Ease ease;
    public float scale = 0.4f;
    private void OnEnable()
    {
        transform.DOScale(Vector3.one * scale, duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }
}
