using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int maxPopulation = 100;

    public int Gold { get; private set; }

    public int Population { get; private set; }

    public event Action<int> GoldChanged = delegate { };
    public event Action<int, int> PopulationChanged = delegate { };
    public event Action LevelWin = delegate { };
    public event Action OnStartNewGame = delegate { };
    public event Action OnLoadNextScene = delegate { };

    public static GameManager Instance { get; private set; }
    public bool CurrentLevelComplete { get; private set; }

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

    public void StartNewGame()
    {
        OnStartNewGame();
    }

    public void SetInitialGold(int gold)
    {
        Gold = gold;
        GoldChanged(Gold);
    }

    public void SetMaxPopulation(int newMaxPopulation)
    {
        Population = 0;
        maxPopulation = newMaxPopulation;
        PopulationChanged(Population, maxPopulation);
    }

    internal void RemoveGold(int v)
    {
        Gold -= v;
        GoldChanged(Gold);
    }

    internal void AddGold(int gold)
    {
        Gold += gold;
        GoldChanged(Gold);
    }

    internal void AddPopulation(int v)
    {
        if (CurrentLevelComplete)
        {
            return;
        }

        Population += v;
        PopulationChanged(Population, maxPopulation);

        if (Population >= maxPopulation)
        {
            LevelWin();
            CurrentLevelComplete = true;
        }
    }

    internal void RemovePopulation(int v)
    {
        Population -= v;
        PopulationChanged(Population, maxPopulation);
    }

    internal void LoadNextScene()
    {
        OnLoadNextScene();
        StartCoroutine(LoadNextSceneAfterSeconds(2));
    }

    private IEnumerator LoadNextSceneAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentLevelComplete = false;
    }
}
