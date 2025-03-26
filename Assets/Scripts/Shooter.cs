using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private float fireSpeed;

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(projectile, spawnTransform.position, Quaternion.identity);
        var currentBulletRigidbody2D = currentBullet.GetComponent<Rigidbody2D>();

        currentBulletRigidbody2D.velocity = new Vector2(fireSpeed * Mathf.Sign(transform.localScale.x), currentBulletRigidbody2D.velocity.y);
    }
}
