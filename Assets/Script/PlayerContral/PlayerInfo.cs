using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据层信息
/// </summary>
public class PlayerInfo : MonoBehaviour {

    public static PlayerInfo instance;
    [SerializeField]private float moveSpeedMultiplier = 1.0f;
    //[SerializeField]private float jumpPowerMultiplier = 1.0f;
    private float DefaultMoveSpeed = 5.0f;

    /// <summary>
    /// 真实移动速度
    /// </summary>
    public float MoveSpeed { get { return moveSpeedMultiplier*DefaultMoveSpeed; } }


    protected virtual void Awake() {
        if (instance == null) {
            instance = this;
        }
        else throw new System.Exception("单例模式被破坏");
    }
    protected virtual void Update() {

    }

}
