using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// This class handle the parry ability of the character.
    /// </summary>
    [AddComponentMenu("Corgi Engine/Character/Abilities/Character Parry")]
    public class CharacterParry : CharacterAbility
    {
        public override string HelpBoxText() { return "CharacterParry."; }

        [Header("Parry Parameters")]
        /// declare your parameters here
        [Tooltip("Duration of the parry window (seconds)")]
        public float parryWindow = 0.3f;
        [Tooltip("Cooldown time after a parry (seconds)")]
        public float parryCooldown = 3f;
        [Tooltip("Optional: how much damage is reduced during parry (1 = full block)")]
        // [Range(0, 1)]
        // public float parryDamageReduction = 1f;

        protected bool _isParrying = false;
        protected bool _isOnCooldown = false;
        protected float _lastParryTime = -999f;

        public bool IsParrying => _isParrying;

        // Animation parameters
        protected const string _parryAnimationName = "Parry";
        protected int _parryAnimationParameter;

        /// <summary>
        /// Here you should initialize our parameters
        /// </summary>
        protected override void Initialization()
        {
            base.Initialization();
        }

        /// <summary>
        /// Every frame, we check if we're crouched and if we still should be
        /// </summary>
        public override void ProcessAbility()
        {
            base.ProcessAbility();
        }

        /// <summary>
        /// Called at the start of the ability's cycle, this is where you'll check for input
        /// </summary>
        protected override void HandleInput()
        {
            // here as an example we check if we're pressing down
            // on our main stick/direction pad/keyboard
			if (_inputManager.ParryButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                TryStartParry();
            }
        }

        /// <summary>
        /// If we're pressing down, we check for a few conditions to see if we can perform our action
        /// </summary>
        protected virtual void TryStartParry()
        {
            // if the ability is not permitted
            if (!AbilityPermitted
                // or if parry is on cooldown
                || _isOnCooldown
                // or if we're not in our normal stance
                || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal)
                // or if we're not grounded
                || (!_controller.State.IsGrounded)
                // or if we're gripping
                || (_movement.CurrentState == CharacterStates.MovementStates.Gripping))
            {
                // we do nothing and exit
                return;
            }

            StartCoroutine(ParryCoroutine());
        }

        protected virtual IEnumerator ParryCoroutine()
        {
            // start parry
            _isParrying = true;
            _isOnCooldown = true;
            _lastParryTime = Time.time;

            // change state
            _condition.ChangeState(CharacterStates.CharacterConditions.Parry);
            MMAnimatorExtensions.SetAnimatorTrigger(_animator, _parryAnimationParameter, _character._animatorParameters);

            MMDebug.DebugLogTime("Parry started!");

            // wait a frame to ensure the animation has started
            yield return null;

            // set character invulnerable to damage
            _health.Invulnerable = true;

            // adjust animation speed to fit the parry window
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            float clipLength = stateInfo.length;
            float speedFactor = clipLength / parryWindow;

            _animator.speed = speedFactor;
            MMDebug.DebugLogTime($"Parry animation adjusted: clipLength={clipLength:F2}, window={parryWindow:F2}, speed={speedFactor:F2}");

            // hold parry window
            yield return new WaitForSeconds(parryWindow);

            // reset animation speed
            _animator.speed = 1f;

            EndParry();

            // start cooldown
            yield return new WaitForSeconds(parryCooldown);
            _isOnCooldown = false;
            MMDebug.DebugLogTime("Parry cooldown finished");
        }

        protected virtual void EndParry()
        {
            if (!_isParrying) return;

            _isParrying = false;
            _condition.ChangeState(CharacterStates.CharacterConditions.Normal);
            _health.Invulnerable = false;

            MMDebug.DebugLogTime("Parry ended");
        }

        /// <summary>
        /// Adds required animator parameters to the animator parameters list if they exist
        /// </summary>
        protected override void InitializeAnimatorParameters()
        {
            RegisterAnimatorParameter(_parryAnimationName, AnimatorControllerParameterType.Trigger, out _parryAnimationParameter);
        }

        /// <summary>
        /// At the end of the ability's cycle,
        /// we send our current crouching and crawling states to the animator
        /// </summary>
        public override void UpdateAnimator()
        {
            //MMAnimatorExtensions.UpdateAnimatorBool(_animator, _parryAnimationParameter, _isParrying, _character._animatorParameters);
        }

        /// <summary>
        /// Returns the damage multiplier based on whether the character is currently parrying or not.
        /// </summary>
        /// <returns></returns>
        // public float GetParryDamageMultiplier()
        // {
        //     if (_isParrying)
        //     {
        //         MMDebug.DebugLogTime("Parry successful! Damage reduced.");
        //     }
        //     return _isParrying ? (1f - parryDamageReduction) : 1f;
        // }
    }
}