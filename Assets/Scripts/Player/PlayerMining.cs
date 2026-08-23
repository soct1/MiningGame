using UnityEngine;

public class PlayerMining : MonoBehaviour
{
    [Header("Mining")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackInterval = 1f;
    [SerializeField] private float damageRadius = 1.5f;

    private float attackTimer;

    private void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer > 0f)
            return;

        attackTimer = attackInterval;

        MineNearbyMines();
    }

    private void MineNearbyMines()
    {
        Mine[] mines = FindObjectsByType<Mine>();

        Vector2 playerPosition = transform.position;

        foreach (Mine mine in mines)
        {
            if (mine == null)
                continue;

            float distanceSqr =
                ((Vector2)mine.transform.position - playerPosition).sqrMagnitude;

            if (distanceSqr <= damageRadius * damageRadius)
            {
                mine.TakeDamage(damage);
            }
        }
    }
}