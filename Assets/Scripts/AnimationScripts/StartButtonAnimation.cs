using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class StartButtonAnimation : SimpleAnimation
{
    [SerializeField] private float _jumpPosition;
    [SerializeField] private float _fallPosition;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(OnTigger);
    }

    public override void Animate()
    {
        _button.onClick.RemoveListener(OnTigger);

        RectTransform rectTransform = (RectTransform)transform;

        DOTween.Sequence()
            .Append(rectTransform.DOAnchorPosY(_jumpPosition, Duration))
            .Append(rectTransform.DOAnchorPosY(_fallPosition, Duration))
            .SetEase(EaseType)
            .onComplete += () => gameObject.SetActive(false);
    }
}
