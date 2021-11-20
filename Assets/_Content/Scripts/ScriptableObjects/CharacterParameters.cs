using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CHR_Parameters", menuName = "Data/CHR_Parameters", order = 1)]
public class CharacterParameters : ScriptableObject
{
    public float moveSpeed;
    public float rotateSpeed;
    public float minStopDistance;
    public float bulletForce;
    public float impactForce;

    public GameObject bloodParticle;
    public LayerMask mask;
}
