using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;


namespace NodeCanvas.Tasks.Actions {

	public class RoamAT : ActionTask {

		public BBParameter<float> IdleTime;
        private NavMeshAgent navAgent;

        //roam example
        public float wanderRadius;
        public float wandercircledistance;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {


            SetDestination();
        }

        private void SetDestination()
        {
            Vector3 circlecenter = agent.transform.position + agent.transform.forward * wandercircledistance;
            Vector3 randompoint = Random.insideUnitCircle.normalized * wanderRadius;
            Vector3 destination = circlecenter + new Vector3(randompoint.x, agent.transform.position.y, randompoint.y);


            VisualizeWander(circlecenter, destination, 5f);


            //If mesh hits destination
            NavMeshHit hit;
            if (NavMesh.SamplePosition(destination, out hit, 10f, NavMesh.AllAreas))
            {
                navAgent.SetDestination(hit.position);
            }

        }



        private void VisualizeWander(Vector3 currentCircleCenter, Vector3 currentDestination, float pathUpdateFrequency)
        {
            Debug.DrawLine(agent.transform.position, currentCircleCenter, Color.red, pathUpdateFrequency);
            for (int i = 0; i < 360; i += 12)
            {
                Vector3 p1 = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), 0f, Mathf.Sin(i * Mathf.Deg2Rad)) * wanderRadius;
                Vector3 p2 = new Vector3(Mathf.Cos((i + 12) * Mathf.Deg2Rad), 0f, Mathf.Sin((i + 12) * Mathf.Deg2Rad)) * wanderRadius;

                Debug.DrawLine(currentCircleCenter + p1, currentCircleCenter + p2, Color.cyan, pathUpdateFrequency);
            }

            Debug.DrawLine(agent.transform.position, currentDestination, Color.magenta, pathUpdateFrequency);
        }


        //Called once per frame while the action is active.
        protected override void OnUpdate() {
            if (navAgent.remainingDistance < 0.7f &&
          !navAgent.pathPending)
            {
                SetDestination();
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}