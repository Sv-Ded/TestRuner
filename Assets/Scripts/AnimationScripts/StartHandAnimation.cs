using DG.Tweening;
using UnityEngine;

public class StartHandAnimation : SimpleAnimation
{
    [SerializeField] private float _movingPosX;

    public override void Animate()
    {
        RectTransform rectTransform = (RectTransform)transform;

        rectTransform.DOAnchorPosX(_movingPosX, Duration)
            .SetEase(EaseType)
            .SetLoops(Repeats, LoopType);
    }
}
