using RPG.Movement;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange=2f;
        [SerializeField] float timeBetweenAttacks=1f;
        float timeSinceLastAttack = 0f;
        Transform target;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;

            if (!GetsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }




        }

        private void AttackBehaviour()
        {
            if (timeSinceLastAttack >timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
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

        //AnimationEvent
        void Hit() { }
    }
}

