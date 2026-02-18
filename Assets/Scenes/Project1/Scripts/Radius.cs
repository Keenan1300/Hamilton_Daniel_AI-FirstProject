using JetBrains.Annotations;
using NodeCanvas.Framework;
using NUnit.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Radius : MonoBehaviour
{
    Color PlayerinRangeColor = Color.red;
    Color PlayeroutColor = Color.white;
    Color patrol = Color.yellow;
    Color current;
    public LayerMask playerlayer;
    public GameObject Dragon;
    public GameObject Player;
    public Transform player;
    private float radius;
    public Blackboard DragonDetection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Access car speed
        Blackboard DragonDetection = Dragon.GetComponent<Blackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        radius = DragonDetection.GetVariableValue<float>("Radius");

        //wherever object is in space, it will do a mathematical scan checking if anything is witihn X units of this objects' space
        Collider[] objectsinrange = Physics.OverlapSphere(transform.position, 20f, playerlayer);
        foreach (Collider PlayerRange in objectsinrange)
        {

            Blackboard PlayerData = PlayerRange.gameObject.GetComponentInParent<Blackboard>();


            if (objectsinrange != null)
            {
                DrawCircle(transform.position, radius, PlayerinRangeColor, 36);

            }
            else if (objectsinrange == null) 
            {
                DrawCircle(transform.position, radius, PlayeroutColor, 36);
                Debug.LogError("car is not in range");
            }
            
        }

      

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
