using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private float _cooldown;
    [SerializeField] private bool _cooldownPassed = true;

    private void Awake()
    {
        if (_currentWeapon != null)
        {
            SetCurrentWeapon(_currentWeapon);
        }
    }

    public void SetCurrentWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        weapon.SetShootPoint(_shootPoint);
    }

    private void Update()
    {
        if (_currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _cooldownPassed || Input.GetKeyDown(KeyCode.Space) && _cooldownPassed)
            {
                _currentWeapon.Shoot();
                StartCoroutine(StartCooldown());
            }
        }
    }

    private IEnumerator StartCooldown()
    {
        _cooldownPassed = false;
        yield return new WaitForSeconds(_cooldown);
        _cooldownPassed = true;
    }
}
