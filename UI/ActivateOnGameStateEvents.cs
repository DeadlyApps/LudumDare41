using UnityEngine;

public class ActivateOnGameStateEvents : MonoBehaviour
{

    [SerializeField]
    private bool activateOnWin;

    [SerializeField]
    private bool activateOnNewGame;

    [SerializeField]
    private bool activateOnLoadNewScene;

    private void Start()
    {
        SetActiveOnAllChildren(false);
        GameManager.Instance.LevelWin += HandleWin;
        GameManager.Instance.OnStartNewGame += HandleNewGame;
        GameManager.Instance.OnLoadNextScene += HandleLoadNextScene;

    }

    private void HandleLoadNextScene()
    {
        SetActiveOnAllChildren(activateOnLoadNewScene);
    }

    private void HandleWin()
    {
        SetActiveOnAllChildren(activateOnWin);
    }

    private void HandleNewGame()
    {
        SetActiveOnAllChildren(activateOnNewGame);
    }

    public void SetActiveOnAllChildren(bool active)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(active);
        }
    }

}
