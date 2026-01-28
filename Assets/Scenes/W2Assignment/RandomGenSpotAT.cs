using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RandomGenSpotAT : ActionTask {

        public Transform targetTransform;
        public BBParameter<float> speed;
        public BBParameter<float> FuelLevel;
        public BBParameter<float> rateoffeulloss;
        public bool random;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            //targetTransform.position = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-15f, 15f));
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            if (random)
            {
                targetTransform.position = new Vector3(Random.Range(30f, 13f), -0f, Random.Range(5f, -6f));
            }


            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            //consume fuel as you move
            FuelLevel.value -= speed.value / rateoffeulloss.value * Time.deltaTime;

            //move obj towards target
            Vector3 directiontoMove = targetTransform.position - agent.transform.position;

            agent.transform.position += directiontoMove.normalized * speed.value * Time.deltaTime;

            //if target is close enough end task
            float distancetoTarget = directiontoMove.magnitude;
            if (distancetoTarget < 0.5f)
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