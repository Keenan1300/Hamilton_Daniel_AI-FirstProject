using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

        //Timers and fixed data
        public BBParameter<Transform> sleepspot;
        public BBParameter<float> IdleTime;
        public BBParameter<float> Sleepmeter;
        public BBParameter<AnimationClip> Sleep;
        public float SleepRefillRate;
        private NavMeshAgent navAgent;
        private Renderer SleepObj;

        //Animation for triggering sleep
        public BBParameter<Animation> anim;

        //Sleepstone material
        public BBParameter<GameObject> Sleepstone;
        public BBParameter<Material> SleepstoneActive;
        public BBParameter<Material> SleepstoneDormant;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            

            //movement signifiers
            navAgent = agent.GetComponent<NavMeshAgent>();
            anim = agent.GetComponent<Animation>();

            //Sleepstone material changer for signifier
            SleepObj = Sleepstone.value.GetComponent<Renderer>();


            //Set sleepstone to off
            SleepObj.material = SleepstoneDormant.value;

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
          
        }



        //Called once per frame while the action is active.
        protected override void OnUpdate() {

            if (navAgent.remainingDistance < 0.7f &&
             !navAgent.pathPending)
            {
                Sleepmeter.value += SleepRefillRate * Time.deltaTime;
                SleepObj.material = SleepstoneActive.value;
            }
            else
            {
                SleepObj.material = SleepstoneDormant.value;
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
            //Reset stone to be off when sleeping is done
            SleepObj.material = SleepstoneDormant.value;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}