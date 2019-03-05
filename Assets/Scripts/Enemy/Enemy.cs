using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Intro
{
    public class Enemy : MonoBehaviour
    {
        public enum State
        {
            Patrol = 0,
            Seek = 1
        }
        public State currentState = State.Patrol;
        public Transform target;
        public float SeekRadius = 5f;
        public Transform waypointParent;
        public NavMeshAgent agent;

        private Transform[] waypoints; //Creates collection of Transforms
        private int currentIndex = 0; //Keeps track of current element in array
        void Start()
        {
            waypoints = waypointParent.GetComponentsInChildren<Transform>(); //Getting the Transforms of all the children of waypointParent
                                                                             // waypointCount = waypoints.Length; //Sets waypointCount to the total amount of waypoints provided
        }

        private void Update()
        {
            Patrol();
        }

        void Patrol()
        {
            Transform point = waypoints[currentIndex + 1]; //Sets the target point to the current index + 1, skipping the parent
            float distance = Vector3.Distance(transform.position, point.position); //Gets the distance between the agent and its target
                                                                                   // CTRL M + O, to close section, CTRL M + P to open it again
            if (distance < 1.0f)
            {
                currentIndex += 1; //Goes to next element in array
                if (currentIndex >= waypoints.Length - 1)
                {
                    currentIndex = 0; //Resets the array to the first waypoint

                }
            }
            agent.SetDestination(point.position);

            float distToTarget = Vector3.Distance(transform.position, target.position);
            if (distToTarget < SeekRadius)
            {
                currentState = State.Seek;
            }
        }

        void Seek()
        {
            agent.SetDestination(target.position);
        }

    }
} 
