using UnityEngine;

public class Radius : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawCircle(transform.position, 20f,Color.red, 36);
    }

    private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
    {
        Vector3 startPoint, endPoint;
        int anglePerPoint = 360 / numberOfPoints;
        for (int i = 1; i <= numberOfPoints; i++)
        {
            startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i - 1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i - 1)));
            startPoint = center + startPoint * radius;
            endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
            endPoint = center + endPoint * radius;
            Debug.DrawLine(startPoint, endPoint, colour);
        }


    }
}
