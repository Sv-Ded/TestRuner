using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : Window
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private string _startText;
    
    public Button RestartButton { get; private set; }

    private void Awake()
    {
        _startText = _textMeshProUGUI.text;

        RestartButton = GetComponentInChildren<Button>();
    }

    public override void Init()
    {
        gameObject.SetActive(true);
    
        GetComponentInChildren<RetryButtonAnimation>().Animate();

        _textMeshProUGUI.text = _startText + (_wallet.Count*_wallet.Multyplier) + " дол€ров";
    }

    public override void Finish()
    {
        gameObject.SetActive(false);
    }
}
