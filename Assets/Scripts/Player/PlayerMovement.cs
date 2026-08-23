using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerTargeting targeting;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stopDistance = 0.6f;

    private void Update()
    {
        Mine target = targeting.CurrentTarget;

        if (target == null)
            return;

        Vector3 targetPosition = target.transform.position;
        Vector3 direction = targetPosition - transform.position;

        if (direction.sqrMagnitude <= stopDistance * stopDistance)
            return;

        transform.position +=
            direction.normalized * moveSpeed * Time.deltaTime;
    }
}