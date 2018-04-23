using UnityEngine;

public class FrriendlyUnitCollectsGold : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        var goldManager = other.GetComponent<FriendlyGoldManager>();

        if (goldManager != null && !goldManager.HasGold())
        {
            goldManager.AddGold(1);
            AudioManager.Instance.PlayGoldPickup();
        }
    }
}
