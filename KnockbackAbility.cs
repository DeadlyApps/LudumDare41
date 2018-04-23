using UnityEngine;

public class KnockbackAbility : Ability
{

    [SerializeField]
    private GameObject particlePrefab;

    public override void UseAbility()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            var hitLocation = hit.point;
            Instantiate(particlePrefab, hitLocation, Quaternion.identity);
            AudioManager.Instance.PlayKnockback();
            var cast = Physics.OverlapSphere(hitLocation, 5);

            foreach (var item in cast)
            {
                if (item.GetComponent<EnemyUnit>() != null || item.GetComponent<FriendlyUnit>())
                {
                    var direciton = item.transform.position - hitLocation;
                    direciton.Normalize();
                    item.transform.position = item.transform.position + direciton * 10;
                }
            }

        }
    }
}
