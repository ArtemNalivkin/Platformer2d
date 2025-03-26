using System.Collections;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    public float currentHealth { get; private set; }
    private bool isAlive;
    
    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        isAlive = currentHealth > 0;
        if (!isAlive)
        {
            if (gameObject.tag == "Player")
            {
                gameObject.GetComponent<Animator>().SetBool("Death", true);
                StartCoroutine(DeathAnimationCoroutine(gameObject));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DeathAnimationCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(obj);
    }

}
