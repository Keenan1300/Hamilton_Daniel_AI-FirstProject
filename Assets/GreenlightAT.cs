using JetBrains.Annotations;
using NodeCanvas.Framework;
using NUnit.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class GreenlightAT : ActionTask {

        public BBParameter<GameObject> car;
        public BBParameter<int> Index;
        public BBParameter<float> Acceleration;
        public BBParameter<List<GameObject>> Trafficlights;

        //swapsign to red for stop
        public Material Greenlight;

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
            currentspeed += Acceleration.value;
            Carblackboard.SetVariableValue("Speed", currentspeed);


            //Change the material of the selected traffic light
            List<GameObject> Trafficlights = agent.GetComponent<List<GameObject>>();
            
            //set selected list object material to redlight
            GameObject SelectedTrafflight = Trafficlights[Index.value];
            Renderer renderer = SelectedTrafflight.GetComponent<Renderer>();
            renderer.material = Greenlight;

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