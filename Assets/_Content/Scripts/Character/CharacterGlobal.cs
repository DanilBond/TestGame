using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterGlobal : MonoBehaviour
{
    public static CharacterGlobal instance;
    public CharacterParameters parameters;
    public CharacterMovement characterMovement;
    public CharacterAnimations characterAnimations;

    public Components components;

    private void Awake() { if(instance == null) { instance = this; } else if(instance == this) { Destroy(gameObject); } }
}

[System.Serializable]
public class Components
{
    public Camera cam;
    public Cinemachine.CinemachineVirtualCamera cinemachine;
    public Animator anim;
    public NavMeshAgent nma;
}