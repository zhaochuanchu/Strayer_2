using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 实现该接口的脚本在按下退出键(游戏暂停)时会暂时Ban掉
/// </summary>
public interface IBanedScripts { }


public class CanvasConvertSystem : MonoBehaviour {

    public static CanvasConvertSystem instance;

    public GameObject GamingCanvas;
    public GameObject PauseCanvas;
    [Tooltip("预先在list中的GameObject上实现IBanedScripts的脚本会在游戏暂停时ban掉")]
    [SerializeField]private List<GameObject> banedScriptsInGameObject;
    private List<MonoBehaviour> BanedScripts=new List<MonoBehaviour>();
    [SerializeField]private KeyCode EscapeKeyCode = KeyCode.Escape;

    protected virtual void Awake() {
        if (instance != null)
            instance = this;
        else print("单例模式破坏");
    }

    protected virtual void Start() { 
        foreach(GameObject gameObject in banedScriptsInGameObject) {
            AddBanedScriptsInGameObject(gameObject);
        }
    }
    protected virtual void Update() {
        if (Input.GetKeyDown(EscapeKeyCode)) {
            ResponseEscapeKeyCode();
        }
    }

    public void AddBanedScripts<T>(T Script) where T : MonoBehaviour, IBanedScripts {
        BanedScripts.Add(Script);
    }
    /// <summary>
    /// 动态生成的GameObject需要ban掉脚本就手动调用此方法
    /// </summary>
    /// <param name="gameObject"></param>
    public void AddBanedScriptsInGameObject(GameObject gameObject) {
        foreach (MonoBehaviour Script in gameObject.GetComponents<MonoBehaviour>()) {
            if (Script as IBanedScripts != null) {
                BanedScripts.Add(Script);
            }
        }
    }
    private void ResponseEscapeKeyCode() {
        GamingCanvas.SetActive(!GamingCanvas.activeInHierarchy);
        PauseCanvas.SetActive(!GamingCanvas.activeInHierarchy);
        foreach(MonoBehaviour script in BanedScripts) {
            script.enabled = !script.enabled;
        }
    }

}
