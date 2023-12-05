using Reflectis.SDK.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ToggleBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> behaviourComponents;
    [SerializeField] Collider collider;

    List<GameObject> behaviourComponentsReference;

    int currentBehaviourCycle;
    bool isNotInteracted = false;
    private bool isInteractable = true;

    public List<GameObject> BehaviourComponents => behaviourComponents;
    public GameObject InteractionTarget => throw new NotImplementedException();
    public int CurrentBehaviourCycle => currentBehaviourCycle;

    private void Start()
    {
        behaviourComponentsReference = BehaviourComponents;
        foreach (var behaviour in behaviourComponentsReference)
        {
            try
            {
                behaviour.GetComponent<IInteractable>();
            }
            catch
            {
                BehaviourComponents.Remove(behaviour);
            }
        }
        behaviourComponentsReference = BehaviourComponents;
    }

    public void Interact(Action completedCallback = null)
    {
        if (!isInteractable) return;

        if (isInteractable)
        {
            StartCoroutine(CheckSpawnTime());
        }

        try
        {
            behaviourComponents[CurrentBehaviourCycle].GetComponent<IInteractable>().Interact();
            if (currentBehaviourCycle != 0 && isNotInteracted)
            {
                behaviourComponents[CurrentBehaviourCycle - 1].GetComponent<IInteractable>().Interact();
            }
            isNotInteracted = true;
            currentBehaviourCycle++;
        }
        catch
        {
            try
            {
                behaviourComponents[CurrentBehaviourCycle - 1].GetComponent<IInteractable>().Interact();
                behaviourComponents[behaviourComponents.Count].GetComponent<IInteractable>().Interact();
                currentBehaviourCycle = 1;
            }
            catch (ArgumentOutOfRangeException e)
            {
                behaviourComponents[0].GetComponent<IInteractable>().Interact();
                currentBehaviourCycle = 0;
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