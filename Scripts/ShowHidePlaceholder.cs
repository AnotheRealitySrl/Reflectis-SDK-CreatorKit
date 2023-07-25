using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virtuademy.DTO;
using static BaseShowHideController;

namespace Virtuademy.Placeholders
{
    public class ShowHidePlaceholder : SceneComponentPlaceholderBase
    {
        [Header("Network settings")]
        [SerializeField] private Role ownershipMask;

        [Header("Show Hide references")]
        [SerializeField] private bool haveToToggle;
        [SerializeField] private List<GameObject> connectables;
        [SerializeField] private bool canBeInteractable;
        [SerializeField] private bool haveToWait;
        [SerializeField] private bool haveToDisableAtStart = false;
        [SerializeField] private HideShowState state = HideShowState.Hiding;
        [SerializeField] private float timeToTriggerAction;
        [SerializeField] private GameObject fatherConnecter;
        [SerializeField] private MeshRenderer mesh;
        [SerializeField] private Collider colliderArea;

        public Role OwnershipMask  => ownershipMask;

        public bool HaveToToggle  => haveToToggle;
        public List<GameObject> Connectables => connectables;
        public bool CanBeInteractable => canBeInteractable;
        public HideShowState State  => state;
        public float TimeToTriggerAction => timeToTriggerAction;
        public bool HaveToWait  => haveToWait;
        public bool HaveToDisableAtStart => haveToDisableAtStart;
        public GameObject FatherConnecter  => fatherConnecter;
        public MeshRenderer Mesh => mesh;
        public Collider ColliderArea => colliderArea;
    }
}
