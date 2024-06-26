using UnityEngine;

namespace HL
{
    public class CharacterManager : MonoBehaviour
    {
        [HideInInspector] public Transform _transform { get; private set; }
        [HideInInspector] public CharacterLocomotion characterLocomotion { get; private set; }
        [HideInInspector] public CharacterStatsManager characterStatsManager { get; private set; }
        [HideInInspector] public CharacterSoundFXManager characterSoundFXManager { get; private set; }
        [HideInInspector] public CharacterAnimatorManager characterAnimatorManager { get; private set; }

        protected float deltaUpdate;
        protected float deltaFixedUpdate;

        [Header("Transforms")]
        public Transform lineOfSightTransform;

        [Header("Character Flags")]
        public bool isRunning;
        public bool isGrounded;
        public bool isJumping;
        public bool isDashing;
        public bool isCrouching;
        public bool isOnSlope;
        public bool isDead;
        public bool isFacingRight;
        public bool isInvulnerable;
        public bool isPerformingAction;
        public bool isDoingMeleeAttack;
        public bool isDoingRangedAttack;
        public bool isBeingDamaged;
        public bool isOnPlatform;

        protected virtual void Awake()
        {
            _transform = transform;
            characterLocomotion = GetComponent<CharacterLocomotion>();
            characterStatsManager = GetComponent<CharacterStatsManager>();
            characterSoundFXManager = GetComponent<CharacterSoundFXManager>();
            characterAnimatorManager = GetComponent<CharacterAnimatorManager>();
        }

        protected virtual void Update()
        {
            if (isDead) return;

            deltaUpdate = Time.deltaTime;
            characterLocomotion.LocomotionUpdate(deltaUpdate);
        }

        protected virtual void FixedUpdate()
        {
            if (isDead) return;

            deltaFixedUpdate = Time.fixedDeltaTime;
            characterLocomotion.LocomotionFixedUpdate(deltaFixedUpdate);
        }
    }
}