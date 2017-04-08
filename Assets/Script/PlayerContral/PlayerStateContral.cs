using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// View层信息
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateContral : MonoBehaviour {

    public static PlayerStateContral instance;
    public Camera MainCamera;
    public GameObject GamingCanvas;
    public Animator playerAnimator;
    public CharacterController playerCharacterController;


    protected virtual void Awake() {
        if (instance == null) {
            instance = this;
        }
        else throw new System.Exception("单例模式被破坏");

        playerAnimator = GetComponent<Animator>();
        playerCharacterController = GetComponent<CharacterController>();
    }

    protected virtual void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }


}
