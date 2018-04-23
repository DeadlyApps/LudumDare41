using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {


    [SerializeField]
    private float timeScale;

    private void Start()
    {
         timeScale = 1;
    }

    private void Update()
    {
        Time.timeScale = timeScale;
    }
}
