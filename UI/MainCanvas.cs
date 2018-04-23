using UnityEngine;

public class MainCanvas : MonoBehaviour {

    public static MainCanvas Instance { get; private set; }

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
    }

}
