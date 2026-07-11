using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        public GunBase gunBase;

        private void OnEnable()
        {
            // Em vez de chamar direto, espera o próximo frame para garantir que está ativo
            StartCoroutine(WaitAndShootCoroutine());
        }

        private void OnDisable()
        {
            if (gunBase != null)
            {
                gunBase.StopShoot();
            }
        }

        private IEnumerator WaitAndShootCoroutine()
        {
            // Espera até o fim do frame atual. Assim o Unity ativa o objeto 100%
            yield return new WaitForEndOfFrame();

            if (gunBase != null)
            {
                gunBase.StartShoot();
            }
        }

        protected override void Init()
        {
            base.Init();
        }
    }
}
