using UnityEngine;
using IA26Online.Decision.StateMachine;
using IA26Online.Decision.StateMachine.Actions;
using IA26Online.Steering;
using IA26Online.Steering.Kynematic.Delegation;

namespace IA26Online.Decision.StateMachine
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class BossController : MonoBehaviour
    {
        //todas las variables necesarias para las acciones que va a realizar
        private Rigidbody2D rb;
        private HierarchicalSM stateMachine;

        [Header("PLAYER")]
        [SerializeField] public Transform playerTransform;
        public bool player_attacks = false;

        [Header("HEALTH")]
        [SerializeField] public float max_health = 100f;
        public float current_health;

        [Header("SPEED")]
        [SerializeField] public float speed = 3f;
        [SerializeField] public float speed_boost = 5f;

        [Header("DISTANCEs")]
        [SerializeField] public float melee_dist = 2f;
        [SerializeField] public float range_dist = 5f;
        [SerializeField] public float radius_dist = 10f;

        [Header("STEERING")]
        public SteeringOutput steering;
        [SerializeField] public KWander wander;
        [SerializeField] public KPursue pursue;
        [SerializeField] public KFlee flee;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            current_health = max_health;
        }
        private void Start()
        {
            stateMachine = BossSMBuilder.Build(this); //FALTA EL BUILDER
        }

        private void Update()
        {
            if (stateMachine == null)
                return;

            Action[] actions = stateMachine.Update();

            if (actions == null)
                return;

            foreach (Action action in actions)
                action.Execute();
            
            ApplySteering();
        }

        private void ApplySteering()
        {
            if (steering.linear.magnitude > 0f == true)
                rb.linearVelocity = steering.linear;

            if (steering.angular != 0f == true)
                rb.angularVelocity = steering.angular;
        }

        public void TakeDamage(float damage)
        {
            current_health -= damage;

            if (current_health < 0f == true)
                current_health = 0f;
        }
        public void SpeedBoost()
        {
            speed = speed_boost;
        }
        public void SetPlayerAttacks(bool value)
        {
            player_attacks = value;
        }
    }
}

