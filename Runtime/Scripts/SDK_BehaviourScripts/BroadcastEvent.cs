using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reflectis.SDK.CreatorKit
{
    public class BroadcastEvent : MonoBehaviour
    {
        [SerializeField] List<GameObject> connectables;

        private bool isInteractable = true;
        public List<GameObject> Connectables => connectables;

        private void Start()
        {
            CheckConnectables();
        }

        /// <summary>
        /// Function to check the validation of connectables list
        /// </summary>
        private void CheckConnectables()
        {
            List<GameObject> referenceList = new List<GameObject>();

            if (Connectables != null && Connectables.Count != 0)
            {
                foreach (var connectable in Connectables)
                {
                    try
                    {
                        connectable.GetComponent<IConnectable>();
                    }
                    catch
                    {
                        referenceList.Add(connectable);
                    }
                }
            }

            for (var i = 0; i < referenceList.Count; i++)
            {
                Connectables.Remove(referenceList[i]);
            }
        }

        public void TriggerConnectables()
        {
            if (!isInteractable) return;

            if (isInteractable)
            {
                StartCoroutine(CheckSpawnTime());
            }

            if (Connectables.Count != 0)
            {
                foreach (var connectable in Connectables)
                {
                    if (connectable != null)
                    {
                        connectable.GetComponent<IConnectable>().TriggerAction();
                    }
                }
            }
        }

        private IEnumerator CheckSpawnTime()
        {
            isInteractable = false;

            yield return new WaitForSeconds(.5f);

            isInteractable = true;
        }
    }
}
