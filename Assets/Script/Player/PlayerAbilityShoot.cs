using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    [Header("Configuração de Armas")]
    public List<GunBase> gunPrefabs;
    public Transform gunPosition;

    private GunBase _currentGun;

    protected override void Init()
    {
        base.Init();

        if (gunPrefabs != null && gunPrefabs.Count > 0)
        {
            CreateGun(0);
        }

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();

        inputs.Gameplay.Weapon1.performed += ctx => ChangeWeapon(0);
        inputs.Gameplay.Weapon2.performed += ctx => ChangeWeapon(1);
    }

    private void CreateGun(int index)
    {
        _currentGun = Instantiate(gunPrefabs[index], gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void ChangeWeapon(int index)
    {
        if (gunPrefabs == null || index >= gunPrefabs.Count || gunPrefabs[index] == null) return;

        if (_currentGun != null)
        {
            _currentGun.StopShoot();
            Destroy(_currentGun.gameObject);
        }

        CreateGun(index);
    }

    private void StartShoot()
    {
        if (_currentGun != null)
        {
            _currentGun.StartShoot();
            Debug.Log("Start Shoot");
        }
    }

    private void CancelShoot()
    {
        if (_currentGun != null)
        {
            Debug.Log("Cancel Shoot");
            _currentGun.StopShoot();
        }
    }
}
