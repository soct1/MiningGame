using UnityEngine;

public class MiningArea : MonoBehaviour
{
    [Header("Spawn Area")]
    [SerializeField] private float width = 12f;
    [SerializeField] private float height = 7f;

    public Vector2 GetRandomPosition()
    {
        float x = Random.Range(-width / 2f, width / 2f);
        float y = Random.Range(-height / 2f, height / 2f);

        return transform.position + new Vector3(x, y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(
            transform.position,
            new Vector3(width, height, 0f)
        );
    }
}