using Reflectis.SDK.Core;
using Reflectis.SDK.NetworkingSystem;
using Unity.VisualScripting;

namespace Reflectis.SDK.CreatorKit
{
    [UnitTitle("Reflectis Networking: On Other Player Left")]
    [UnitSurtitle("Networking")]
    [UnitShortTitle("On Other Player Left")]
    [UnitCategory("Events\\Reflectis")]
    public class OnOtherPlayerLeftEventNode : EventUnit<(int, int)>
    {
        public static string eventName = "NetworkingOnOtherPlayerLeft";

        [DoNotSerialize]
        public ValueOutput UserId { get; private set; }
        [DoNotSerialize]
        public ValueOutput PlayerId { get; private set; }
        protected override bool register => true;

        protected GraphReference graphReference;

        public override EventHook GetHook(GraphReference reference)
        {
            graphReference = reference;

            SM.GetSystem<INetworkingSystem>().OtherPlayerLeftRoom.AddListener(OnPlayerLeft);

            return new EventHook(eventName);
        }

        protected override void Definition()
        {
            base.Definition();
            UserId = ValueOutput<int>(nameof(UserId));
            PlayerId = ValueOutput<int>(nameof(PlayerId));
        }

        protected override void AssignArguments(Flow flow, (int, int) args)
        {
            flow.SetValue(UserId, args.Item1);
            flow.SetValue(PlayerId, args.Item2);
        }

        private void OnPlayerLeft(int userId, int playerId)
        {
            Trigger(graphReference, (userId, playerId));
        }
    }
}
