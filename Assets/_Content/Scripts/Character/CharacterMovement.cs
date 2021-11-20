 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    public CharacterMovementComponents components;
    public CharacterMovementParameters parameters;
    private void Start() => components.Nma = CharacterGlobal.instance.components.nma;
    private void FixedUpdate()
    {
        if (!parameters.IsReadyToFire)
            if(Input.GetMouseButtonDown(0))
                MoveToNextWaypoint();

        if (components.Target != null)
        {
            if (components.Nma.remainingDistance <= CharacterGlobal.instance.parameters.minStopDistance)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, components.Target.rotation, Time.deltaTime * CharacterGlobal.instance.parameters.rotateSpeed);
            }
        }
    }
    void MoveToNextWaypoint()
    {
        if (parameters.IsReadyToFire)
            return;

        if (!components.Waypoints[parameters.CurrentWaypoint].isCompleted)
        {
            CharacterGlobal.instance.components.nma.SetDestination(components.Waypoints[parameters.CurrentWaypoint].transform.position);
        }
    }

    public void RotateTo(Transform to) => components.Target = to;
}

[System.Serializable]
public class CharacterMovementParameters
{

    int currentWaypoint = 0;
    public int CurrentWaypoint { get { return currentWaypoint; } set { currentWaypoint = value; } }

    bool isReadyToFire;
    public bool IsReadyToFire { get => isReadyToFire; set => isReadyToFire = value; }

}
[System.Serializable]
public class CharacterMovementComponents
{
    [SerializeField]
    Waypoint[] _waypoints;
    public Waypoint[] Waypoints { get { return _waypoints; } }

    public NavMeshAgent Nma { get => nma; set => nma = value; }
    public Transform Target { get => target; set => target = value; }

    NavMeshAgent nma;
    public Transform target;
}