using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移动控制模块
/// </summary>
public class PlayerMoveSystem : MonoBehaviour,IBanedScripts {

    private Animator playerAnimator;
    private CharacterController playerCharacterContraller;
    private Camera MainCamera;
    private float moveSpeed;
    private bool isMoving = false;
    
    protected virtual void Start() {
        playerAnimator = PlayerStateContral.instance.playerAnimator;
        playerCharacterContraller = PlayerStateContral.instance.playerCharacterController;
        moveSpeed = PlayerInfo.instance.MoveSpeed;
        MainCamera = PlayerStateContral.instance.MainCamera;
    }

	protected virtual void Update () {
        if ((Mathf.Abs(Input.GetAxis("Horizontal")) > 0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0f)) {
            isMoving = true;
            playerAnimator.SetBool("Run", true);
        }
        else {
            playerAnimator.SetBool("Run", false);
            isMoving = false;
        }
    }
    protected virtual void FixedUpdate() {
        if (isMoving) {
            Vector3 rightDir = new Vector3(MainCamera.transform.TransformDirection(Vector3.right).x, 0, MainCamera.transform.TransformDirection(Vector3.right).z).normalized;
            Vector3 forwardDir = new Vector3(MainCamera.transform.TransformDirection(Vector3.forward).x, 0, MainCamera.transform.TransformDirection(Vector3.forward).z).normalized;
            transform.LookAt(transform.position + forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal"));
            playerCharacterContraller.SimpleMove(moveSpeed * (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")));
        }
    }
}
