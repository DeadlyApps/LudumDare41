using UnityEngine;

public class PlayParticleOnKill : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particlePrefab;

    private FriendlyUnit friendlyUnit;

    private void Start()
    {
        friendlyUnit = GetComponent<FriendlyUnit>();
        friendlyUnit.OnKill += HandleOnKill;
    }

    private void HandleOnKill()
    {
        AudioManager.Instance.PlayFriendlyDeathAudio();
        Instantiate(particlePrefab, transform.position, Quaternion.identity);
    }

}