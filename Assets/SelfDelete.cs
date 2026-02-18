using System.Threading;
using UnityEngine;

public class SelfDelete : MonoBehaviour

{

    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
            Destroy(gameObject);
    }
}
