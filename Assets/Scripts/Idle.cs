using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

 

    public class Idle : ActionTask {

        public Transform targetTransform;
		private float CurrentCharge;
        public float speed;
        
		//Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            Blackboard blackbE = agent.GetComponent<Blackboard>();
            CurrentCharge = blackbE.GetVariableValue<float>("CurrentCharge");
            blackbE.SetVariableValue("CurrentCharge", 100f);
            CurrentCharge = 100f;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            Blackboard blackbE = agent.GetComponent<Blackboard>();
            CurrentCharge = blackbE.GetVariableValue<float>("CurrentCharge");
            blackbE.SetVariableValue("CurrentCharge", CurrentCharge - 3f);
            CurrentCharge -= 3f * Time.deltaTime;

        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}