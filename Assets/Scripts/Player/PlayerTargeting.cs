using UnityEngine;

public class PlayerTargeting : MonoBehaviour
{
    [SerializeField] private float targetSearchInterval = 0.2f;

    private Mine currentTarget;
    private float searchTimer;

    public Mine CurrentTarget => currentTarget;

    private void Update()
    {
        searchTimer -= Time.deltaTime;

        if (searchTimer > 0f)
            return;

        searchTimer = targetSearchInterval;

        FindNearestMine();
    }

    private void FindNearestMine()
    {
        Mine[] mines = FindObjectsByType<Mine>();

        Mine nearestMine = null;
        float nearestDistanceSqr = float.MaxValue;

        Vector3 playerPosition = transform.position;

        foreach (Mine mine in mines)
        {
            if (mine == null)
                continue;

            float distanceSqr =
                (mine.transform.position - playerPosition).sqrMagnitude;

            if (distanceSqr < nearestDistanceSqr)
            {
                nearestDistanceSqr = distanceSqr;
                nearestMine = mine;
            }
        }

        currentTarget = nearestMine;
    }
}