using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab; // prefab contenant le Particle System (explosion/fumée)
    [SerializeField] private float hitEffectLifetime = 2f; // sécurité si le Particle System n'a pas "Stop Action = Destroy"
    [SerializeField] private int scoreValue = 10;

    // Permet au TargetSpawner (ou à un système de score) d'être prévenu quand la cible est détruite.
    public event System.Action<Target> OnDestroyed;

    public void Hit()
    {
        if (hitEffectPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, hitEffectLifetime);
        }

        // TODO: brancher un système de score ici si besoin, ex: ScoreManager.Instance.Add(scoreValue);

        OnDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}