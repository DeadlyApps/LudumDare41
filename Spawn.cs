using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private FriendlyUnit SpawnUnitPrefab;

    [SerializeField]
    private float maxTimeTillSpawn = 5f;

    private float timeTillSpawn;

    private void Update()
    {
        if (timeTillSpawn <= 0)
        {
            timeTillSpawn = maxTimeTillSpawn;
            Instantiate(SpawnUnitPrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayPopulationGrowth();
        }
        timeTillSpawn -= Time.deltaTime;
    }

}
