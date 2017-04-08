using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 跳跃控制模块
/// </summary>
public class PlayerJumpSystem : MonoBehaviour,IKey {

    [SerializeField]private KeyCode keyCode = KeyCode.Space;

    public virtual void SetKeyCode(KeyCode keyCode) {
        this.keyCode = keyCode;
    }
    public virtual KeyCode GetKeyCode() {
        return keyCode;
    }
    public virtual void ResponseKey() {

    }
    protected virtual void Update() {
        if (Input.GetKeyDown(keyCode)) {
            ResponseKey();
        }
    }

}
