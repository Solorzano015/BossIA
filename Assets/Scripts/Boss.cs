using IA26Online.Decision.BehaviorTree;
//using IA26Online.Decision.BehaviorTree.BossIA;
using IA26Online.Decision.BehaviorTree.Conditions;
using IA26Online.Decision.BehaviorTree.Actions;
using IA26Online.Decision.BehaviorTree.Decorators.Sample;
using IA26Online.Steering.Combination.Blending;
using IA26Online.Steering;
using UnityEngine;

namespace IA26Online.Agents
{
    public class Boss : MonoBehaviour
    {
        [Header("Referencias")]
        [SerializeField] private Transform player;

        [Header("Vida")]
        [SerializeField] private float health = 100f;
        [SerializeField] private float currentHealth = 100f;

        [Header("Velocidad")]
        [SerializeField] private float speed = 5f;
        [SerializeField] private float speedBoost = 1.5f;
        public bool SpeedBoosted { get; private set; }



        [Header("Rangos de decisión")]
        [SerializeField] private float attackRange = 2f;        // rango de ataque cuerpo a cuerpo
        [SerializeField] private float rangedAttackRange = 8f;  // Y - rango de ataque a distancia
        [SerializeField] private float detectionRange = 15f;    // Z - rango de detección del jugador

        [Header("Steering Behaviours")]
        [SerializeField] private SteeringBehaviour fleeBehaviour;   // KFlee
        [SerializeField] private SteeringBehaviour seekBehaviour;   // KSeek
        [SerializeField] private SteeringBehaviour pursueBehaviour; // KPursue
        [SerializeField] private SteeringBehaviour wanderBehaviour; // KWander
        [SerializeField] private BlenderSteering blender;

        private Task root;
        private bool inPhase2 = false;

        // Propiedades públicas para que las tasks del árbol puedan leer el estado del Boss
        public Transform Player => player;
        public float Health { get => health; set => health = value; }
        public float AttackRange => attackRange;
        public float RangedAttackRange => rangedAttackRange;
        public float DetectionRange => detectionRange;
        public SteeringBehaviour FleeBehaviour => fleeBehaviour;
        public SteeringBehaviour SeekBehaviour => seekBehaviour;
        public SteeringBehaviour PursueBehaviour => pursueBehaviour;
        public SteeringBehaviour WanderBehaviour => wanderBehaviour;

        /* para no crear los scriptable objects
        private void Awake()
        {
            BuildTree();
        }

        */
        private void Update()
        {
            root.Run();
        }
        /*
        private void BuildTree()
        {
            // -- decision de aatque --
            Task attackSelector = new Selectors(new Task[]
            {
                new Sequences(new Task[]
                {
                    new IsNear(this),
                    new MeleeAttackAction(this),
                    new StaysNear(this),
                    new CounterAttackAction(this)
                }),
                new Sequences(new Task[]
                {
                    new Inverter(new IsNear(this)),
                    new RangeAttackAction(this)
                })
            });

            // --- Distancia de Jugador ---
            Task distanceTree = new Selectors(new Task[]
            {
                attackSelector,
                new Sequences(new Task[] // Jugador demasiado lejos para ser detectado (>Z)
                {
                    new DistanceGreaterThanDetectionRange(this),
                    new WanderAction(this)
                }),
                new Sequences(new Task[] // +Distancia que rango de ataque distancia (>Y y <Z)
                {
                    new DistanceGreaterThanRangedAttackRange(this),
                    new DistanceLessThanDetectionRange(this),
                    new PursueAction(this)
                })
            });

            // --- RootBoss ---
            root = new Selectors(new Task[]
            {
                new Sequences(new Task[] { new HealthBelow25(this), new FleeAction(this) }),
                new Sequences(new Task[] { new HealthBelow50(this), new IncreaseSpeedAction(this) }),
                distanceTree
            });
        }
        */
        public void EnterPhase2()
        {
            if (inPhase2) return;
            inPhase2 = true;

            // movementSpeed = rageSpeed; // si se manejan variables propias
            blender.max_lineal_velocity *= speedBoost; // o directamente sobre el blenderSteering
        }
    }
}