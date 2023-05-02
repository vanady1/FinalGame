using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _money;
    private PlayerShoot _playerShoot;

    public event UnityAction<int> Changed;
    public int Money => _money;

    public void AddMoney(int amount)
    {
        _money += amount;
        Changed.Invoke(_money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _money -= weapon.Price;
        Changed.Invoke(_money);
        _playerShoot.SetCurrentWeapon(weapon);
    }

    private void Awake()
    {
        _playerShoot = GetComponent<PlayerShoot>();
    }
}
