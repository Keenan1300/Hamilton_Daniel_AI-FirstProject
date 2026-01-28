using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RegenerateindexAT : ActionTask {

        public Color scanColour = new Color(255, 255, 255, 20);
        public int numberOfScanCirclePoints;
        public LayerMask targetmask;
        public GameObject objectsinrange;
        public float radius;
        public float scanspeed = 5f;
        public float scanrangemax = 20f;
		public int ObjectIndex;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			ObjectIndex = Random.Range(0,9);
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