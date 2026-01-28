using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class YellowLightAT : ActionTask {

        public BBParameter<int> Index;
        public BBParameter<GameObject> car;
        public BBParameter<float> decelerationrate;
        public BBParameter<List<GameObject>> Trafficlights;


        //swapsign to yellow for yield
        public Renderer Renderer;
        public Material Yellowlight;

        public BBParameter<float> Trafficradius;
        public LayerMask carmask;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

          


            //Change the material of the selected traffic light
            int i = Index.value;

            // Change material of selected traffic light
            GameObject selectedTrafficLight = Trafficlights.value[i];
            Renderer renderer = selectedTrafficLight.GetComponent<Renderer>();
            renderer.material = Yellowlight;


            //Check if car is within range of the traffic light
            Collider[] carsinrange = Physics.OverlapSphere(selectedTrafficLight.transform.position, Trafficradius.value, carmask);
            foreach (Collider objectinrange in carsinrange)
            {
                Blackboard carblackboard = objectinrange.gameObject.GetComponentInParent<Blackboard>();

                //access car speed
                Blackboard Carblackboard = car.value.GetComponent<Blackboard>();
                float currentspeed = Carblackboard.GetVariableValue<float>("Speed");
                currentspeed = 2;
                Carblackboard.SetVariableValue("Speed", currentspeed);


                if (carblackboard == null)
                {
                    Debug.LogError("car is not in range");
                }


            }

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