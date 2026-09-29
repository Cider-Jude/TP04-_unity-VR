using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float lifeTime = 5f;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        // Sur Unity < 6000.x, utilise rb.velocity au lieu de rb.linearVelocity

        Destroy(gameObject, lifeTime);
    }
}