using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Parameters parameters;
    public EnemyComponents components;

    private void Awake()=> components.anim = GetComponent<Animator>();
    void Start() { SwitchRagdoll(false); }

    public void Die()
    {
        if (parameters.IsImmortal)
            return;

        if (!parameters.IsDied)
        {
            SwitchRagdoll(true);
            components.Waypoint.KilledEnemies++;
            parameters.IsDied = true;
        }
    }

    public void SwitchRagdoll(bool active)
    {
        components.anim.enabled = !active;
        foreach (Rigidbody i in parameters.ragdollComponents)
        {
            i.isKinematic = !active;
            i.useGravity = active;
        }
    }
}

[System.Serializable]
public class Parameters
{
    [SerializeField]
    public Rigidbody[] ragdollComponents;

    bool isImmortal = true;
    bool isDied = false;
    public bool IsDied { get => isDied; set => isDied = value; }
    public bool IsImmortal { get => isImmortal; set => isImmortal = value; }
}

[System.Serializable]
public class EnemyComponents
{
    public Animator anim;

    [SerializeField]
    Waypoint waypoint;
    public Waypoint Waypoint { get => waypoint; set => waypoint = value; }
}