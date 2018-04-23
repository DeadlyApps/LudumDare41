using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip friendlyDeath;

    [SerializeField]
    private AudioClip freeze;

    [SerializeField]
    private AudioClip goldCollect;

    [SerializeField]
    private AudioClip goldPickup;

    [SerializeField]
    private AudioClip haste;

    [SerializeField]
    private AudioClip knockback;

    [SerializeField]
    private AudioClip populationGrowth;

    [SerializeField]
    private AudioClip slow;

    private AudioSource audioSource;

    public static AudioManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFriendlyDeathAudio()
    {
        audioSource.PlayOneShot(friendlyDeath);
    }

    public void PlayFreeze()
    {
        audioSource.PlayOneShot(freeze);
    }

    public void PlayGoldCollect()
    {
        audioSource.PlayOneShot(goldCollect);
    }

    public void PlayGoldPickup()
    {
        audioSource.PlayOneShot(goldPickup);
    }

    public void PlayHaste()
    {
        audioSource.PlayOneShot(haste);
    }

    public void PlayKnockback()
    {
        audioSource.PlayOneShot(knockback);
    }

    public void PlayPopulationGrowth()
    {
        audioSource.PlayOneShot(populationGrowth);
    }

    public void PlaySlow()
    {
        audioSource.PlayOneShot(slow);
    }
}
