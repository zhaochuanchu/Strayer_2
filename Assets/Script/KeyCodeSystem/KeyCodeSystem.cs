using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 按键交互功能
/// </summary>
public interface IKey {
    /// <summary>
    /// 设置按键响应
    /// </summary>
    /// <param name="keyCode">所设置的按键</param>
    void SetKeyCode(KeyCode keyCode);

    /// <summary>
    /// 获取响应模块的按键设置
    /// </summary>
    /// <returns></returns>
    KeyCode GetKeyCode();

    /// <summary>
    /// 响应按键
    /// </summary>
    void ResponseKey();

}

public static class KeyCodeSystem{


    public static void SetKeyCode<T>(T TSystem,KeyCode keyCode) where T :IKey{
        TSystem.SetKeyCode(keyCode);
    }
	public static KeyCode GetKeyCode<T>(T TSystem) where T : IKey {
        return TSystem.GetKeyCode();
    }
    public static void ResponseKey<T>(T TSystem)where T : IKey {
        TSystem.ResponseKey();
    }
}
