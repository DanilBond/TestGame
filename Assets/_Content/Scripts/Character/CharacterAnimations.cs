using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimations : MonoBehaviour
{
    NavMeshAgent nma;
    Animator anim;
    private void Start()
    {
        nma = CharacterGlobal.instance.components.nma;
        anim = CharacterGlobal.instance.components.anim;
    }
    private void FixedUpdate() => anim.SetBool("isWalking", nma.remainingDistance >= CharacterGlobal.instance.parameters.minStopDistance);
}
