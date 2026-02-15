using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

        public BBParameter<Transform> sleepspot;
        public BBParameter<float> IdleTime;
        private NavMeshAgent navAgent;





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
   
            Vector3 Sleeppoint = sleepspot.value.position;
            
            navAgent.SetDestination(Sleeppoint);
            

        }


        //Called once per frame while the action is active.
        protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}