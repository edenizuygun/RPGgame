using RPG.Movement;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange=2f;
        Transform target;
        private void Update()
        {
            if (target == null) return;

            if (!GetsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
            }
            
           


        }
        private bool GetsInRange() 
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }
        public void Attack(CombatTarget combatTarget) 
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            Debug.Log("hiya");
        }
        public void Cancel() { target = null; }

        
    }
}

