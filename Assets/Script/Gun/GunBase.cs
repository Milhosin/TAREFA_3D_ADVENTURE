using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    public float speed = 50f;

    private Coroutine _currentCoroutine;

    protected virtual IEnumerator ShootCoroutine()
    {
        while (true)
        {
            // ADICIONADO: Avisa se a corrotina está rodando o tiro
            Debug.Log("GunBase: Rodando o loop e chamando o Shoot()!");

            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile, positionToShoot.position, positionToShoot.rotation);
        projectile.speed = speed;
    }

    public void StartShoot()
    {
        StopShoot();

        if (gameObject.activeInHierarchy)
        {
            // ADICIONADO: Avisa que passou no teste e vai ligar a corrotina
            Debug.Log("GunBase: Objeto ativo! Iniciando a corrotina de tiro...");
            _currentCoroutine = StartCoroutine(ShootCoroutine());
        }
        else
        {
            // ADICIONADO: Avisa se o Unity barrou o tiro por estar inativo
            Debug.LogWarning("GunBase: O tiro NÃO iniciou porque o GameObject está INATIVO!");
        }
    }

    public void StopShoot()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
}
