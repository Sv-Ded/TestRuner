using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Count { get; private set; } = 30;

    public int Multyplier { get; private set; } = 1;

    public event Action MoneyHasSpended;

    public event Action MoneyCountChanged;

    public void Reset()
    {
        Count = 30;
        Multyplier = 1;
        MoneyCountChanged?.Invoke();
    }

    private void Awake()
    {
        MoneyCountChanged?.Invoke();
    }

    public void SpendMoney(int price)
    {
        if (Count - price > 0)
        {
            Count -= price;
        }
        else
        {
            MoneyHasSpended?.Invoke();
        }

        MoneyCountChanged?.Invoke();
    }

    public void AddMoney(int price)
    {
        Count+=price;

        MoneyCountChanged?.Invoke();

        Debug.Log(Count.ToString());
    }

    public void AddMultyplyer() => Multyplier++;
}
