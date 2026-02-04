using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class HideAT : ActionTask {

		public BBParameter<Transform> targetTransform;
		public float fleedistance;
		private NavMeshAgent navAgent;
        public float hidefreq;
        private float timeSinceLasthide = 0f;

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

		void SetDestination()
		{
            Vector3 directionawayFromtarget = agent.transform.position - targetTransform.value.position;
            Vector3 targetpos = directionawayFromtarget.normalized * fleedistance + agent.transform.position;
            navAgent.SetDestination(targetpos);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{

			timeSinceLasthide += Time.deltaTime;

			if (timeSinceLasthide > hidefreq)
			{
				SetDestination();
                timeSinceLasthide = 0f;
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