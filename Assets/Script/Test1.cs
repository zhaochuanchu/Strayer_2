using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
using DG.Tweening;

public class Test1 : MonoBehaviour {

    public KeyCode keyCode = KeyCode.J;

    protected virtual void Awake() {

    }
	protected virtual void Update () {
        if (Input.GetKeyDown(keyCode)) {
            TestDOTween();
        }
	}

    [ContextMenu("ConnectWorkAndTakeQuery")]
    private void Connect() {
        //ConnectNetWork.ConnectMyAzure();
        Debug.Log(Application.persistentDataPath);
    }

    /// <summary>
    /// 定义一个测试类
    /// </summary>
    public class TestClass {
        public string Name = "刘老四";
        public float Age = 23.0f;
        public int Sex = 1;

        public List<int> Ints = new List<int>()
        {
            1,
            2,
            3
        };
    }

    [ContextMenu("TakeJsonTest")]
    private void JsonTest() {
        //定义存档路径
        string dirpath = Application.persistentDataPath + "/Save";
        //创建存档文件夹
        JsonHelper.CreateDirectory(dirpath);
        //定义存档文件路径
        string filename = dirpath + "/GameData.sav";
        TestClass t = new TestClass();
        //保存数据
        JsonHelper.SetData(filename, t);
        //读取数据
        TestClass t1 = (TestClass)JsonHelper.GetData(filename, typeof(TestClass));

        Debug.Log(t1.Name);
        Debug.Log(t1.Age);
        Debug.Log(t1.Ints);
    }

    [ContextMenu("XMLTest")]
    private void XMLTest() {
        XMLHelper.LoadXML("ThingsInfo.xml");
    }
    [ContextMenu("TestNextItem")]
    public void TestNextItem() {
        print(BagSystem.instance.NextItem);
    }

    [ContextMenu("ForeachComponent")]
    public void ForeachComponent() {
        foreach(MonoBehaviour m in GetComponents<MonoBehaviour>()) {
            if(m as IBanedScripts != null) {
                Debug.Log("true");
                return;
            }
        }
        Debug.Log("false");
    }

    [ContextMenu("DOTweenTest")]
    private void TestDOTween() {
        this.transform.DOMove(new Vector3(2, 0, 0), 2.0f).SetRelative();
    }

}
