using UnityEngine;

public class EnemyDropHunter : MonoBehaviour
{
    public float searchRange = 50f;
    public float moveSpeed = 4f;
    private Transform targetDrop;

    void Update()
    {
        // Search for a drop if we don't have one
        if (targetDrop == null)
        {
            FindClosestDrop();
        }
        else
        {
            // Move towards the drop
            MoveToDrop();
        }
    }

    void FindClosestDrop()
    {
        GameObject[] drops = GameObject.FindGameObjectsWithTag("Airdrop");
        float closestDistance = searchRange;

        foreach (GameObject drop in drops)
        {
            float distance = Vector3.Distance(transform.position, drop.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetDrop = drop.transform;
            }
        }
    }

    void MoveToDrop()
    {
        if (targetDrop != null)
        {
            Vector3 direction = (targetDrop.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            transform.LookAt(targetDrop);
        }
    }
}
