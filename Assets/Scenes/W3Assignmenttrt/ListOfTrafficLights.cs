using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class ListOfTrafficLights : MonoBehaviour
{

    public List<GameObject> enemyObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            List<GameObject> Lights = new List<GameObject>();
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
