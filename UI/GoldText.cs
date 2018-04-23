using System;
using TMPro;
using UnityEngine;

public class GoldText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.GoldChanged += HandleGoldChanged;
        HandleGoldChanged(GameManager.Instance.Gold);
    }

    private void HandleGoldChanged(int gold)
    {
        textMesh.text = gold + "";
    }
}
