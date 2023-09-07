using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Virtuademy.DTO;

namespace Reflectis.SDK.CreatorKit
{
    public class UsablePlaceholder : SceneComponentPlaceholderNetwork
    {
        public enum UseInteractionState
        {
            SingleUse,
            MultipleUse
        }

        public enum UseType
        {
            NotPickable,
            NotUsable,
            ChangeColor,
            Empty,
        }

        //[Header("Network settings")]
        //[SerializeField] private Role ownershipMask;

        [Header("Pickable references")]
        [SerializeField] private UseInteractionState state = UseInteractionState.SingleUse;
        [SerializeField] private UseType usableType;
        [SerializeField] private bool canBeUsed;

        //public Role OwnershipMask { get => ownershipMask; set => ownershipMask = value; }
        public UseInteractionState State { get => state; set => state = value; }
        public UseType UsableType { get => usableType; set => usableType = value; }
        public bool CanBeUsed { get => canBeUsed; set => canBeUsed = value; }
    }
}
