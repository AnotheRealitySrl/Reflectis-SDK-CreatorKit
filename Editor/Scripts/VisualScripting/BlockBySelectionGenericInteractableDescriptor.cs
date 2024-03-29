using Reflectis.SDK.CreatorKit;
using Unity.VisualScripting;

namespace Reflectis.SDK.CreatorKitEditor
{
    [Descriptor(typeof(BlockBySelectionGenericInteractableUnit))]
    public class BlockBySelectionGenericInteractableDescriptor : UnitDescriptor<BlockBySelectionGenericInteractableUnit>
    {
        public BlockBySelectionGenericInteractableDescriptor(BlockBySelectionGenericInteractableUnit unit) : base(unit) { }

        protected override string DefinedSummary()
        {
            return "This unit will enable or disable the interaction with a given GenericInteractable element.";
        }
    }
}
