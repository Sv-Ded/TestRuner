using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainWindow : Window
{
    [SerializeField] private Wallet _wallet;

    private TextMeshProUGUI _textMeshProUGUI;
    private string _startText;

    private void Awake()
    {
        _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    
        _startText = _textMeshProUGUI.text;
    }

    private void OnEnable()
    {
        _wallet.MoneyCountChanged += Render;
    }

    private void OnDisable()
    {
        _wallet.MoneyCountChanged -= Render;
    }

    public override void Init()
    {
        gameObject.SetActive(true);
    }

    public override void Finish()
    {
        gameObject.SetActive(false);
    }

    private void Render()
    {
        _textMeshProUGUI.text = _startText + "\n Денег: " + _wallet.Count + " x " + _wallet.Multyplier + ".0";
    }
}