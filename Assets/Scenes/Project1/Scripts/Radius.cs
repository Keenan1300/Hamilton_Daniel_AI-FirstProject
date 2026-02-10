using UnityEngine;

public class Radius : MonoBehaviour
{
    Color PlayerinRange = Color.red;
    Color Playerout = Color.white;
    Color patrol = Color.yellow;
    Color current;
    public LayerMask playerlayer;

    public Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //wherever object is in space, it will do a mathematical scan checking if anything is witihn X units of this objects' space
        Collider[] objectsinrange = Physics.OverlapSphere(transform.position, 20f, playerlayer);
        foreach (Collider objectinrange in objectsinrange)
        {


            DrawCircle(transform.position, 20f, PlayerinRange, 36);

        }
       
        DrawCircle(transform.position, 20f, PlayerinRange, 36);
        
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
