using UnityEngine;

public class Projectile : MonoBehaviour {
    public float lifetime = 5f;
    public int damage = 10;
    public float explosionRadius = 2f;
    private float spawnTime;

    void Start() {
        spawnTime = Time.time;
    }

    void Update() {
        if (Time.time >= spawnTime + lifetime) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision) {
        HandleCollision(collision.gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        HandleCollision(collision.gameObject);
    }

    void HandleCollision(GameObject other) {
        if (other.CompareTag("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        } else if (other.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}