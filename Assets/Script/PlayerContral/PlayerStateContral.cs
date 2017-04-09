using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// View层信息
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateContral : MonoBehaviour ,IBanedScripts{

    public static PlayerStateContral instance;
    public Camera MainCamera;
    public GameObject GamingCanvas;

    [HideInInspector]public Animator playerAnimator;
    [HideInInspector]public CharacterController playerCharacterController;


    protected virtual void Awake() {
        if (instance == null) {
            instance = this;
        }
        else throw new System.Exception("单例模式被破坏");

        playerAnimator = GetComponent<Animator>();
        playerCharacterController = GetComponent<CharacterController>();
    }

    protected virtual void Update() {

    }


}
