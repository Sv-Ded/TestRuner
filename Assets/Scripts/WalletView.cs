using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private Slider _slider;
    private float _speed = 0.01F;
    private float _maxValue = 200;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
    }

    private void OnEnable()
    {
        _wallet.MoneyCountChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _wallet.MoneyCountChanged -= UpdateValue;
    }

    private void UpdateValue()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        Debug.Log("slider value: " + _slider.value);

        _coroutine = StartCoroutine(UpdateValueCoroutine());
    }

    private IEnumerator UpdateValueCoroutine()
    {
        float target = (float)_wallet.Count / _maxValue;

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speed);

            yield return null;
        }
    }
}
