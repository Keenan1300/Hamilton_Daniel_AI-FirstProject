using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class RadiusTripCT : ConditionTask {

		//Get radius Object
        public BBParameter<GameObject> GoldPile;
        public BBParameter<float> Radius;
        public BBParameter<LayerMask> Player;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;


		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {

       
       
        }

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            //Check if player enters gold radius
            Collider[] playerinrange = Physics.OverlapSphere(GoldPile.value.transform.position, Radius.value, Player.value);
            foreach (Collider objectinrange in playerinrange)
            {
                Blackboard playerblackboard = objectinrange.gameObject.GetComponentInParent<Blackboard>();



                if (playerblackboard == null)
                {
                    Debug.LogError("car is not in range");
                    return playerblackboard;
                }

            }

            return playerinrange != null;
        }
	}
}