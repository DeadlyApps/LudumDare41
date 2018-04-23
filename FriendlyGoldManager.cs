using UnityEngine;

public class FriendlyGoldManager : MonoBehaviour
{
    private int gold;

    [SerializeField]
    private ParticleSystem goldPrefab;

    internal bool HasGold()
    {
        return gold > 0;
    }

    internal void AddGold(int v)
    {
        goldPrefab.gameObject.SetActive(true);
        if (goldPrefab.isStopped)
        {
            goldPrefab.Play();
        }
        gold += v;
    }

    internal void DeliverGold()
    {

        goldPrefab.gameObject.SetActive(false);
        GameManager.Instance.AddGold(gold);
        gold = 0;
    }

}
