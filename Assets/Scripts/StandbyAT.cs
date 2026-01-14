using NodeCanvas.Framework;
using UnityEngine;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class StandbyAT : ActionTask {

        public int num = 2;
		public Material Standby; 

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            Renderer renderer = agent.gameObject.GetComponent<Renderer>();
            //renderer.material = ;
            agent.transform.position += Vector3.right;
            agent.GetComponent<Rigidbody>();

            //end action stops behaviours
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