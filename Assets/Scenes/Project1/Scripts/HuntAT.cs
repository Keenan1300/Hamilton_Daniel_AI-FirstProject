using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;


namespace NodeCanvas.Tasks.Actions {

	public class HuntAT : ActionTask {

        private NavMeshAgent navAgent;
        private Blackboard Playerprox;
        public BBParameter<Transform> GuardSpot;
        public BBParameter<Transform> Playerlocation;
        public BBParameter<float> DragonRadius;
        public BBParameter<bool> Ontopofplayer;
        public BBParameter<float> GaurdTime;
        public BBParameter<GameObject> player;
        public BBParameter<LayerMask> playerlayer;
        public float waittime;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            Playerprox = agent.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            SetDestination();

            //Check if player is within range of the dragon
            Collider[] playerinrange = Physics.OverlapSphere(agent.transform.position, DragonRadius.value, playerlayer.value);
            foreach (Collider objectinrange in playerinrange)
            {
               

                // Access player
                Blackboard playerblackboard = player.value.GetComponent<Blackboard>();
                float currentSpeed = playerblackboard.GetVariableValue<float>("Speed");



                if (playerblackboard == null)
                {
                    Playerprox.SetVariableValue("OntopOfPlayer", false);
                    Debug.LogError("car is not in range");
                }
                else
                {
                    Playerprox.SetVariableValue("OntopOfPlayer", true);
                    Debug.Log("is on top");
                }


            }



        }

        private void SetDestination()
        {

            Vector3 PlayerHunt = Playerlocation.value.position;

            navAgent.SetDestination(PlayerHunt);

            //If dragon is on top of player than activate boolean. This acts as transition for flame
            if (navAgent.remainingDistance < 30f &&
             !navAgent.pathPending)
            {
                Playerprox.SetVariableValue("OntopOfPlayer", true);
                Ontopofplayer.value = true;
                Debug.Log("is on top");
            }
            else 
            {
                Playerprox.SetVariableValue("OntopOfPlayer", false);
                Ontopofplayer.value = false;
                Debug.Log("is NOT on top");
            }

        }

        private void GuardAction()
        {
            Debug.Log("isguarding");

            Vector3 Playerpos = Playerlocation.value.position;
            navAgent.SetDestination(Playerpos);
            navAgent.speed = 0.1f;

        }


        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}