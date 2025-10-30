using UnityEngine;
using UnityEngine.InputSystem;

public class GunShooter : MonoBehaviour
{
    [Header("References")]
    public Transform muzzlePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public AudioSource shootSound;
    public ParticleSystem muzzleFlash;

    [Header("Input")]
    public InputActionProperty shootAction; // koppel aan je XR controller trigger

    void Update()
    {
        if (shootAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Maak een kogel aan
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = muzzlePoint.forward * bulletSpeed;

        // Optionele effecten
        if (shootSound) shootSound.Play();
        if (muzzleFlash) muzzleFlash.Play();

        // Vernietig de kogel na een tijdje
        Destroy(bullet, 3f);
    }
}
