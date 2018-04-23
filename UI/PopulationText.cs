using TMPro;
using UnityEngine;

public class PopulationText : MonoBehaviour
{

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.PopulationChanged += HandlePopulationChanged;
    }

    private void HandlePopulationChanged(int population, int maxPopulation)
    {
        textMesh.text = population + "/" + maxPopulation;
    }
}
