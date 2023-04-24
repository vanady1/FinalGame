using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    private TMP_Text _count;

    private void Awake()
    {
        _count = GetComponent<TMP_Text>();        
    }

    private void OnEnable()
    {
        _playerMoney.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _playerMoney.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _count.text = money.ToString();
    }
}
