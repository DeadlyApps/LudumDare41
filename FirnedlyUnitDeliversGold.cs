using UnityEngine;

public class FirnedlyUnitDeliversGold : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var friendlyUnit = other.GetComponent<FriendlyGoldManager>();

        if (friendlyUnit != null && friendlyUnit.HasGold())
        {
            friendlyUnit.DeliverGold();
            AudioManager.Instance.PlayGoldCollect();
        }
    }
}