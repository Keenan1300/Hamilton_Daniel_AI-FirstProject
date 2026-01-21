using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;

namespace NodeCanvas.Tasks.Actions {

	public class RedlightAT : ActionTask {

		public BBParameter<GameObject> car;
        public BBParameter<float> decelerationrate;

		//swapsign to red for stop
        public Material Redlight;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			//access car speed
            Blackboard Carblackboard = car.value.GetComponent<Blackboard>();
            float currentspeed = Carblackboard.GetVariableValue<float>("Speed");
            currentspeed = 0;
            Carblackboard.SetVariableValue("Speed", currentspeed);


            //set self material to redlight
            Renderer renderer = agent.gameObject.GetComponent<Renderer>();
			renderer.material = Redlight;

			

            EndAction(true);
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