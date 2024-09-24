using System;
using UnityEngine;

[RequireComponent(typeof(SplineFolower))]
public class Player : MonoBehaviour
{
    [SerializeField] private ViewSwitch _viewSwitch;
    [SerializeField] private ColisionDetecter _colisionDetecter;
    [SerializeField] private Wallet _wallet;

    private SplineFolower _folower;
    private int _index;
    private Transform _checkpointTransform;

    public event Action GameOver;
    public event Action LevelComplete;

    private void Awake()
    {
        _folower = GetComponent<SplineFolower>();
    }

    private void OnEnable()
    {
        _colisionDetecter.InteractableObjectTriggered += OnTriggered;
        _wallet.MoneyHasSpended += LoseGame;
    }

    private void OnDisable()
    {
        _colisionDetecter.InteractableObjectTriggered -= OnTriggered;
        _wallet.MoneyHasSpended -= LoseGame;
    }

    private void Start()
    {
        _index = _viewSwitch.VariantsCount - 1;

        _viewSwitch.GetModel(_index).gameObject.SetActive(true);
    }

    private void OnTriggered(IInteractableObject interactableObject)
    {
        if (interactableObject is Money money)
        {
            money.OnTrigered();
            _wallet.AddMoney(money.Price);
        }
        else if (interactableObject is Beer beer)
        {
            beer.OnTrigered();
            _wallet.SpendMoney(beer.Price);
        }
        else if (interactableObject is CheckPoint checkpoint)
        {
            _checkpointTransform = checkpoint.transform;
        }
        else if (interactableObject is Gate gate)
        {
            if (gate.TryOpen(_wallet.Count))
            {
                _wallet.AddMultyplyer();
            }
            else
            {
                LevelComplete?.Invoke();
            }
        }
        else if(interactableObject is Finish)
        {
            LevelComplete?.Invoke();
        }
    }

    private void LoseGame()
    {
        GameOver?.Invoke();
    }

    public void Restart()
    {
        _folower.Restart();
        _wallet.Reset();
    }
}
