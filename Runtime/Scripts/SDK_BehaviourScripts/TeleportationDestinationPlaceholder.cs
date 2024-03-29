using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reflectis.SDK.CreatorKit
{
    public class TeleportationDestinationPlaceholder : SceneComponentPlaceholderBase
    {
        [SerializeField, Tooltip("Write the teleportation point's name that will appear in the map")] private string teleportAreaName;

        public string TeleportAreaName => teleportAreaName;
    }
}
