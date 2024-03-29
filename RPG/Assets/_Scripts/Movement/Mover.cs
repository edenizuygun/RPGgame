
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour,IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent nav;

        Ray lastRay;
        // Start is called before the first frame update
        void Start()
        {
            nav = gameObject.GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {

            UpdateAnimator();


        }


        public void StartMoveAction(Vector3 destination) 
        {
            GetComponent<ActionScheduler>().StartAction(this);
            
            MoveTo(destination);
        }
        public void MoveTo(Vector3 destination)
        {
            nav.destination = destination;
            nav.isStopped = false;
        }
        
        void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        }

        public void Cancel()
        {
            nav.isStopped = true;
        }
    }
}
