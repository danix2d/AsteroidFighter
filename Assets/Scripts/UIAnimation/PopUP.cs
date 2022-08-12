using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUP : MonoBehaviour
{
    public float time;
    public float delay;

    public Ease enEase;
    public Ease disEase;

    public Vector3 scale;

    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(scale, time).SetEase(enEase).SetDelay(delay);
    }

    public void DisableBtn()
    {
        transform.DOScale(Vector3.zero, time).SetEase(disEase).SetUpdate(true);
    }

    public void EnableBtn()
    {
        transform.DOScale(scale, time).SetEase(enEase).SetDelay(delay).SetLoops(-1, LoopType.Yoyo);
    }

    private void Disabled(){
        this.gameObject.SetActive(false);
    }
}
