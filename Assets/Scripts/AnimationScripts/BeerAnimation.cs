using DG.Tweening;
using UnityEngine;

public class BeerAnimation : SimpleAnimation
{
    public override void Animate()
    {
        transform.DOMove(transform.position+Vector3.up, Duration).SetLoops(Repeats, LoopType.Yoyo).SetEase(EaseType);
    }
}
