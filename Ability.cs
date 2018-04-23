using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Ability : MonoBehaviour
{

    [SerializeField]
    private bool activateOnStart;

    [SerializeField]
    private KeyCode activationKey;

    [SerializeField]
    private int price = 15;

    [SerializeField]
    private float abilityCooldownDuration = 2;

    private bool isActive = false;

    private float timeTillNextUse = 0;
    private Ability[] abilities;

    public abstract void UseAbility();

    public event Action<float> OnTimerUpdate = delegate { };
    public event Action<bool> OnActivationChanged = delegate { };

    private void Awake()
    {
        abilities = FindObjectsOfType<Ability>();
 
    }

    private void Start()
    {
        if (activateOnStart)
        {
            TryActivate();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            TryActivate();
        }
        TruUseAbility();
    }

    public void TryActivate()
    {
        foreach (var ability in abilities)
        {
            ability.Deactivate();
        }
        Activate();
    }

    private void Activate()
    {
        if (!isActive)
        {
            OnActivationChanged(true);
        }

        isActive = true;
    }

    private void Deactivate()
    {
        if (isActive)
        {
            OnActivationChanged(false);
        }
        isActive = false;
    }

    private void TruUseAbility()
    {
        timeTillNextUse -= Time.deltaTime;
        float updatePercentage = 1 - Mathf.Clamp(timeTillNextUse / abilityCooldownDuration, 0, 1);
        OnTimerUpdate(updatePercentage);
        if (CanUseAbility())
        {
            timeTillNextUse = abilityCooldownDuration;
            UseAbility();
            GameManager.Instance.RemoveGold(price);
        }
    }

    private bool CanUseAbility()
    {
        return !EventSystem.current.IsPointerOverGameObject()
                    && isActive
                    && Input.GetButtonDown("Fire1")
                    && GameManager.Instance.Gold >= price && timeTillNextUse < 0;
    }
}
