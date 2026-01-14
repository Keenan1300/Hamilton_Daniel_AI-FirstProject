using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public Transform targetTransform;
		public BBParameter<float> speed;
		//anywhere that acceses BBparameter must have the suffix of .value at its end

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

			//Blackboard blackb = agent.GetComponent<Blackboard>();
			//speed = blackb.GetVariableValue<float>("speed");

			//blackb.SetVariableValue("speed",0f);

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
			
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//move obj towards target
			Vector3 directiontoMove = targetTransform.position - agent.transform.position;
			
			agent.transform.position += directiontoMove.normalized * speed.value * Time.deltaTime;
			
			float distancetoTarget = directiontoMove.magnitude;
			if(distancetoTarget < 0.5f)
			{
				EndAction(true);
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