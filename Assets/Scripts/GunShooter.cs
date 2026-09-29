using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables; // namespace pour XRI 3.x

public class GunShooter : MonoBehaviour
{
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] private float fireRate = 0.2f; // délai mini entre 2 tirs

    private float nextFireTime;

    private void OnEnable()
    {
        grabInteractable.activated.AddListener(OnActivate);
    }

    private void OnDisable()
    {
        grabInteractable.activated.RemoveListener(OnActivate);
    }

    private void OnActivate(ActivateEventArgs args)
    {
        if (Time.time < nextFireTime) return;
        Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        nextFireTime = Time.time + fireRate;
    }
}