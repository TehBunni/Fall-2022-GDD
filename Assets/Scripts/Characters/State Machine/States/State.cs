using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Patrol,
    Chase,
    Fire,
}

[CreateAssetMenu(menuName = "StateMachine/State")]
public class State : ScriptableObject
{
    [SerializeField] private EnemyState state;
    [SerializeField] private Transition[] transitions;

    public virtual void ExecuteActions(GameObject entity)
    {
        switch (state)
        {
            case EnemyState.Patrol:
                entity.GetComponent<EnemyMovement>().ExecutePatrolState();
                break;
            case EnemyState.Fire:
                entity.GetComponentInChildren<EnemyBase>().ExecuteFireState();
                break;
            case EnemyState.Chase:
                entity.GetComponentInChildren<EnemyBase>().ExecuteChaseState();
                break;
            default:
                break;
        }
    }

    public virtual void ExecuteEntryActions(GameObject entity)
    {

    }

    public virtual void ExecuteExitActions(GameObject entity)
    {

    }

    public Transition[] GetTransitions()
    {
        return transitions;
    }
}
