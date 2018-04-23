using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIconTimer : MonoBehaviour
{
    private Image icon;

    [SerializeField]
    private Ability ability;

    private void Awake()
    {
        icon = GetComponent<Image>();
        ability.OnTimerUpdate += UpdateTimer;
    }

    private void UpdateTimer(float percentage)
    {
        icon.fillAmount = percentage;
    }
}
