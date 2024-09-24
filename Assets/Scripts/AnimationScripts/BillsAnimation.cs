using DG.Tweening;
using UnityEngine;

public class BillsAnimation : SimpleAnimation
{
    private void Start()
    {
        OnTigger();
    }

    public override void Animate()
    {
        transform.DORotate(Vector3.up * 10, Duration).SetLoops(Repeats, LoopType);
    }
}
