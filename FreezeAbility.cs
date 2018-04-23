using UnityEngine;

public class FreezeAbility : Ability
{

    [SerializeField]
    private GameObject particlePrefab;

    [SerializeField]
    private float freezeDuration = 5f;

    public override void UseAbility()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            var hitLocation = hit.point;
            GameObject particle = Instantiate(particlePrefab, hitLocation + Vector3.up, Quaternion.Euler(-90, 0, 0));
            AudioManager.Instance.PlayFreeze();
            Destroy(particle, freezeDuration);

            var cast = Physics.OverlapSphere(hitLocation, 5);
            foreach (var item in cast)
            {
                EnemyUnit enemyUnit = item.GetComponent<EnemyUnit>();
                if (enemyUnit != null)
                {
                    enemyUnit.Freeze(freezeDuration);
                }
                FriendlyUnit friendlyUnit = item.GetComponent<FriendlyUnit>();
                if (friendlyUnit != null)
                {
                    friendlyUnit.Freeze(freezeDuration);
                }
            }
        }
    }
}
