using UnityEngine;
using UnityEngine.UI;

public class AbilityHalo : MonoBehaviour
{
    private Image icon;

    [SerializeField]
    private Ability ability;

    private void Awake()
    {
        icon = GetComponent<Image>();
        ability.OnActivationChanged += HandleActivationChanged;
    }

    private void HandleActivationChanged(bool isActive)
    {
        icon.enabled = isActive;
    }
}