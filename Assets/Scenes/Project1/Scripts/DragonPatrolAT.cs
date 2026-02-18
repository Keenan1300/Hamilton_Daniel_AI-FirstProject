using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

    public class DragonPatrolAT : ActionTask {

        //Patrol points
        public BBParameter<List<Transform>> PatrolRoutes;

        //Timers and data
        public BBParameter<float> IdleTime;
        public BBParameter<float> SleepMeter;
        public BBParameter<float> Threshold;

        //Which spot on patrol?
        public BBParameter<int> PatrolCycle;

        //nav
        private NavMeshAgent navAgent;

        //Critical Locations
        public BBParameter<Transform> SleepSpot;
        public BBParameter<Transform> GoldPile;
        public BBParameter<GameObject> DragonMesh;


        //roam example
        public float wanderRadius;
        public float wandercircledistance;


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
            int i = PatrolCycle.value;

            Transform selectedPatrolPoint = PatrolRoutes.value[i];
            SetDestination(selectedPatrolPoint.position);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            if (PatrolRoutes == null)
            {
                EndAction();
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}



        private void SetDestination(Vector3 Patrolpoint)
        {

            navAgent.SetDestination(Patrolpoint);

            //If dragon is on top of player than activate boolean. This acts as transition for flame
            if (navAgent.remainingDistance < 5f &&
             !navAgent.pathPending)
            {
                PatrolCycle.value += 1;
            }

        }

    }
}