using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damageble") )
        {
            other.gameObject.GetComponentInParent<HealthBehaviour>().TakeDamage(damage);
            Debug.Log("Hit");
        }

        if (gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
