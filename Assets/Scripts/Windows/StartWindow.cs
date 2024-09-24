using UnityEngine;

public class StartWindow : Window
{
    public override void Init()
    {
        gameObject.SetActive(true);

        GetComponentInChildren<StartHandAnimation>().Animate();

    }

    public override void Finish()
    {
        gameObject.SetActive(false);
    }
}
