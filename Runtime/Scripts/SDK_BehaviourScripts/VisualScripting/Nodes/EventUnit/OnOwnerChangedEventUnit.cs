using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Reflectis.SDK.CreatorKit
{
    [UnitTitle("Synced Object: On Owner Changed")]
    [UnitSurtitle("Synced Object")]
    [UnitShortTitle("On Owner Changed")]
    [UnitCategory("Events\\Reflectis\\Ownership")]
    [TypeIcon(typeof(Material))]
    public class OnOwnerChangedEventUnit : EventUnit<SyncedObject>
    {
        public static string eventName = "SyncedObjectOnOwnerChanged";
        public static List<OnOwnerChangedEventUnit> instances = new List<OnOwnerChangedEventUnit>();

        [NullMeansSelf]
        [PortLabelHidden]
        [DoNotSerialize]
        public ValueInput syncedObjectRef { get; private set; }
        protected override bool register => true;

        public static GraphReference graphReference;

        public override EventHook GetHook(GraphReference reference)
        {
            graphReference = reference;
            return new EventHook(eventName);
        }

        protected override void Definition()
        {
            base.Definition();
            syncedObjectRef = ValueInput<SyncedObject>(nameof(syncedObjectRef), null).NullMeansSelf();

            if (!instances.Contains(this))
            {
                instances.Add(this);
            }
        }

        protected override bool ShouldTrigger(Flow flow, SyncedObject args)
        {
            if (args == null)
            {
                return false;
            }
            if (flow.GetValue<SyncedObject>(syncedObjectRef) == args)
            {
                return true;
            }
            return false;
        }
    }
}
