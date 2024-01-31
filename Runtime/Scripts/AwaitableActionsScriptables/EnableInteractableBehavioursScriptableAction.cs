using Reflectis.SDK.InteractionNew;

using System.Threading.Tasks;

using UnityEngine;

using static Reflectis.SDK.InteractionNew.IInteractable;

namespace Reflectis.SDK.CreatorKit
{
    [CreateAssetMenu(menuName = "Reflectis/Scriptable Actions/EnableInteractableBehavioursScriptableAction", fileName = "EnableInteractableBehavioursScriptableAction")]
    public class EnableInteractableBehavioursScriptableAction : AwaitableScriptableAction
    {
        [SerializeField] private bool activate;
        [SerializeField] private EInteractableType interactionsToEnable;

        public override Task Action(IInteractable interactable = null)
        {
            if (interactable != null)
            {
                foreach (var beh in interactable.InteractableBehaviours)
                {
                    if (beh is Manipulable manipulable && interactionsToEnable.HasFlag(EInteractableType.Manipulable))
                        manipulable.CanInteract = activate;

                    if (beh is GenericInteractable genericInteractable && interactionsToEnable.HasFlag(EInteractableType.GenericInteractable))
                        genericInteractable.CanInteract = activate;

                    if (beh is ContextualMenuManageable manageable && interactionsToEnable.HasFlag(EInteractableType.ContextualMenuInteractable))
                        manageable.CanInteract = activate;
                };
            }

            return Task.CompletedTask;
        }
    }
}