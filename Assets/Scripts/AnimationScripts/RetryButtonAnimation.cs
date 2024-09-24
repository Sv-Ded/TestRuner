using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetryButtonAnimation : SimpleAnimation
{
    [SerializeField] private float _maxFade;
    [SerializeField] private float _buttonPosition;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public override void Animate()
    {
        RectTransform rectTransform = (RectTransform) transform;

        DOTween.Sequence()
            .Append(rectTransform.DOAnchorPosX(_buttonPosition, Duration))
            .Append(_text.DOFade(_maxFade, Duration));
    }
}
