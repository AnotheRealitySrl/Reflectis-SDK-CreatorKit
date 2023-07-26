using System.Collections.Generic;

using UnityEngine;

namespace Virtuademy.Placeholders
{
    public class AnimationPlaceholder : SceneComponentPlaceholderNetwork
    {
        public enum AnimationStates
        {
            Playing = 1,
            Paused = 2,
            Stopped = 3
        }

        [Header("Network settings")]
        [SerializeField] private Role ownershipMask;

        [Header("Animation references")]
        [SerializeField] private bool isLooping;
        [SerializeField] private AnimationStates animationState;
        [SerializeField] private Animator animator;
        [SerializeField] private List<GameObject> connectables;
        [SerializeField] private string animationToTrigger;
        [SerializeField] private string animationToResetTrigger;
        [SerializeField] private GameObject fatherConnecter;


        public Role OwnershipMask => ownershipMask;
        public bool IsLooping => isLooping;
        public AnimationStates AnimationState => animationState;
        public Animator Animator => animator;
        public List<GameObject> Connectables => connectables;
        public string AnimationToTrigger => animationToTrigger;
        public string AnimationToResetTrigger => animationToResetTrigger;
        public GameObject FatherConnecter => fatherConnecter;
    }
}