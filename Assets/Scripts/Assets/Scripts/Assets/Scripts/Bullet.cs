using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;

    void Start()
    {
        // Destroy the bullet after its lifetime
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // If it hits an enemy, destroy both or just the bullet
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit!");
            Destroy(gameObject);
        }
    }
}
