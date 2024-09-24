using UnityEngine.UI;

public class GameOverWindow: Window
{
    public Button RestartButton { get; private set; }

    private void Awake()
    {
        RestartButton = GetComponentInChildren<Button>();
    }

    public override void Init()
    {
        gameObject.SetActive(true);

        GetComponentInChildren<RetryButtonAnimation>().OnTigger();
    }

    public override void Finish()
    {
       gameObject.SetActive(false);
    }
}