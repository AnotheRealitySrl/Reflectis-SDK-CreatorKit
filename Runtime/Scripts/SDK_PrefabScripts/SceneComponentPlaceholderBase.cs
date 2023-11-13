using System;
using System.Threading.Tasks;

using UnityEngine;

using Virtuademy.DTO;

namespace Reflectis.SDK.CreatorKit
{
    public abstract class SceneComponentPlaceholderBase : MonoBehaviour
    {
        [SerializeField] private bool automaticSetup = true;

        public bool AutomaticSetup => automaticSetup;

        public virtual async Task Init(SceneComponentsMapper mapper)
        {
            foreach (Type type in mapper.GetComponentsTypes(GetType().ToString().Split('.')[^1]))
            {
                await ((IRuntimeComponent)gameObject.AddComponent(type)).Init(this);
            }
        }

        [ContextMenu("Set All Placeholder New ID")]
        private void SetAllPlaceholderNewID()
        {
            var placeholders = FindObjectsOfType<SceneComponentPlaceholderNetwork>();
            var addressablePlaceholders = FindObjectsOfType<SpawnNetworkedAddressablePlaceholder>();

            if(placeholders.Length != 0)
            {
                for (var i = 0; i < placeholders.Length; i++)
                {
                    if (placeholders[i].IsNetworked)
                    {
                        placeholders[i].InitializationId = i + 1;
                    }


                    if (i == placeholders.Length - 1)
                    {
                        for (var j = 0; j < addressablePlaceholders.Length; j++)
                        {
                            if (addressablePlaceholders[j].IsNetworked)
                            {
                                addressablePlaceholders[j].InitializationId = j + i + 1;
                            }
                        }
                    }
                }
            }
            else
            {
                for (var j = 0; j < addressablePlaceholders.Length; j++)
                {
                    if (addressablePlaceholders[j].IsNetworked)
                    {
                        addressablePlaceholders[j].InitializationId = j + 1;
                    }
                }
            }
        }
    }
}