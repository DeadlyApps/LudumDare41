using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public static PlayerControls Instance { get; private set; }

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
