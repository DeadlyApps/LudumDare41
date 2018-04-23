using UnityEngine;

public class SetSceneLevelValues : MonoBehaviour
{

    [SerializeField]
    private int initialGold;

    [SerializeField]
    private int targetPopulationCount;

    private void Start()
    {
        GameManager.Instance.SetInitialGold(initialGold);
        GameManager.Instance.SetMaxPopulation(targetPopulationCount);
        GameManager.Instance.StartNewGame();
    }

}
