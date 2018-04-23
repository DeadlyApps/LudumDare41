using UnityEngine;

public class SlowAbility : Ability
{

    [SerializeField]
    private float slowDuration = 3f;

    [SerializeField]
    private ParticleSystem particlePrefab;

    public override void UseAbility()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            var hitLocation = hit.point;
            ParticleSystem particle = Instantiate(particlePrefab, hitLocation + Vector3.up, Quaternion.Euler(-90, 0, 0));
            AudioManager.Instance.PlaySlow();
            Destroy(particle.gameObject, slowDuration);
            var cast = Physics.OverlapSphere(hitLocation, 5);
            foreach (var item in cast)
            {
                FriendlyUnit friendlyUnit = item.GetComponent<FriendlyUnit>();
                if (friendlyUnit != null)
                {
                    friendlyUnit.ActivateSlow();
                }
            }
        }
    }
}