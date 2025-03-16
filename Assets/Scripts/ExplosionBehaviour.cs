using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] 
    private GameObject pointEffectorPrefab;

    private bool instantiated = false;

    private void Start()
    {
        instantiated = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !instantiated)
        {
            Debug.Log("Explosion done");
            instantiated = true;
            GameObject pointEffectorGameObject = Instantiate(pointEffectorPrefab, transform);
            StartCoroutine(DeleteObjectCoroutine(pointEffectorGameObject));
        }
    }

    IEnumerator DeleteObjectCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(obj);
    }
}
