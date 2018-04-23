using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void Continue()
    {
        GameManager.Instance.LoadNextScene();
    }
}
