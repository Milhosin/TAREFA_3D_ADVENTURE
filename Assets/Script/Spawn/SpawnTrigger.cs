using UnityEngine;
using DG.Tweening;

public class SpawnTrigger : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("Arraste o inimigo da HIERARCHY para cá")]
    public GameObject enemyToActivate;

    [Tooltip("A Tag que o objeto precisa ter para ativar o gatilho")]
    public string playerTag = "Player";

    [Header("Size Animation Settings")]
    [Tooltip("O tamanho final (Scale) que o inimigo deve alcançar")]
    public float targetSize = 5f;

    [Tooltip("Tempo em segundos para o inimigo crescer")]
    public float animationDuration = 0.5f;

    [Tooltip("Efeito de mola/impacto ao terminar de crescer")]
    public Ease easeType = Ease.OutBack;

    private bool _hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_hasSpawned || enemyToActivate == null) return;

        if (other.CompareTag(playerTag))
        {
            _hasSpawned = true; 

            enemyToActivate.transform.localScale = Vector3.zero;

            enemyToActivate.SetActive(true);

            enemyToActivate.transform.DOScale(new Vector3(targetSize, targetSize, targetSize), animationDuration)
                .SetEase(easeType);

            Debug.Log($"[SpawnTrigger] {enemyToActivate.name} ativado com tamanho {targetSize}!");
        }
    }
}
