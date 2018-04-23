using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField]
    private EnemyUnit enemy;

    [SerializeField]
    private Transform[] patrolPositions;

    private Transform target;
    private int patrolPositionIndex = 0;

    private void Update()
    {
        if (target == null || Vector3.Distance(target.position, enemy.transform.position) < 1f)
        {
            target = patrolPositions[patrolPositionIndex++];
            patrolPositionIndex = patrolPositionIndex % patrolPositions.Length;
            enemy.SetDestination(target.transform.position);
        }
    }
}
