using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab; 
    [SerializeField] private float hitEffectLifetime = 2f; 
    [SerializeField] private int scoreValue = 10;

    public event System.Action<Target> OnDestroyed;

    public void Hit()
    {
        if (hitEffectPrefab != null)
        {
            GameObject effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, hitEffectLifetime);
        }


        OnDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}