using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class ScoutMovement : MonoBehaviour
{


    public NavMeshAgent NavAgent;
    public Vector3 targpos;
    public Transform home;
    public Transform Target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 targpos = new Vector3(Random.Range(20, -20), 0f, Random.Range(20, -20));
        Vector3 Target = transform.position;
        NavAgent.SetDestination(Target);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetpos = Target.transform.position;
        Vector3 Vhome = home.transform.position;
        Vector3 Pos = transform.position;
        Vector3 Direction = (Pos - targpos).normalized;

        float Mag = Direction.magnitude;

        if (Mag < 0.1f)
        {
            ChangeSpot(Vhome);
        }


    }


    public void ChangeSpot(Vector3 newspot)
    {
        Vector3 Vhome = home.transform.position;
        NavAgent.SetDestination(Vhome);

    }
}
