using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Reflectis.SDK.CreatorKit
{
    [AddComponentMenu("")]//For hide from add component menu.
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Variables))]
    public class SyncedVariables : MonoBehaviour
    {
        [System.Serializable]
        public class Data
        {
            [HideInInspector]
            public byte id;
            public string name;
            public bool saveThroughSessions;

            public VariableDeclaration declaration { get; set; }

            public object Value
            {
                get
                {
                    return declaration.value;
                }
            }
        }

        public List<Data> variableSettings = new List<Data>();
        public Dictionary<string, object> variableDictBackup = new Dictionary<string, object>();

        private void Start()
        {
            VariableSet();
        }

        public void VariableSet()
        {
            if (variableDictBackup.Count != variableSettings.Count)
            {
                foreach (Data data in variableSettings)
                {
                    if (data.declaration == null)
                    {
                        var declarations = GetComponent<Variables>().declarations;
                        data.declaration = declarations.GetDeclaration(data.name);
                    }
                    object value = data.Value;
                    variableDictBackup.Add(data.name, value);
                }
            }
        }
    }
}
