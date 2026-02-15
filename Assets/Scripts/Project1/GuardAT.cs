using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;


namespace NodeCanvas.Tasks.Actions {

	public class GuardAT : ActionTask {

        private NavMeshAgent navAgent;
        public BBParameter<Transform> GuardSpot;
        public BBParameter<float> Radius;
        public BBParameter<float> GaurdTime;
        public float waittime;

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

            if (navAgent.remainingDistance < 0.7f &&
     !navAgent.pathPending)
            {
                SetDestination();
               
            }
            else
            {
                GuardAction();
            }
          
        }


        private void SetDestination()
        {

            Vector3 Gaurdpoint = GuardSpot.value.position;

            navAgent.SetDestination(Gaurdpoint);


            if (navAgent.remainingDistance < 0.7f &&
        !navAgent.pathPending)
            {
                GuardAction();
            }

        }

        private void GuardAction()
        {
            Debug.Log("isguarding");

            if (waittime < 1)
            {
                EndAction(true);
            }

        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {

            if (navAgent.remainingDistance < 0.7f &&
        !navAgent.pathPending)
            {
                SetDestination();
                waittime -= 1 * Time.deltaTime;
               
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