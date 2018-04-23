using UnityEngine;

public class EnemiesAttackFriendlyUnits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var friendlyUnit = other.GetComponent<FriendlyUnit>();

        if (friendlyUnit != null)
        {
            friendlyUnit.Kill();
        }
    }
}
