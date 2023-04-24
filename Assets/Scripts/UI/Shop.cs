using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(weapon);
    }

    private void OnSellButtonClick(Weapon weapon, WeaponView weaponview)
    {
        TrySellWeapon(weapon, weaponview);
    }

    private void TrySellWeapon(Weapon weapon, WeaponView weaponView)
    {
        if(weapon.Price <= _playerMoney.Money)
        {
            _playerMoney.BuyWeapon(weapon);
            weapon.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
            weaponView.ItemSold();
        }
    }
}
