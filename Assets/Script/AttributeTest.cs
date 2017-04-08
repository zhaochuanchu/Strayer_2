using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class AttributeTest : MonoBehaviour {

    [ContextMenu("ContextMenuTest")]
    protected virtual void Test() {
        print("ContextMenuTest!");
    }

    //大概只能执行无参方法
    [ContextMenuItem("ContextMenuItemtest","Test2")]
    public int ContextMenuItemTest;
    protected virtual void Test2() {
        print("ContextMenuItemtest!");
    }

    [Header("AHeader")]
    public Material AboutAHeader1;
    public Color AboutAHeader2;

    [HideInInspector]
    public int Hider;

    public TouchType AType;

    [Multiline]
    public string MultilineString;

    [Space(5)]

    [TextArea]
    public string TextAreaString;

    [SerializeField]
    [Range(0.1f, 0.5f)]
    private float RangeFloat;

    [Range(1, 100)]
    public int RangeInt;

    [Tooltip("This is a GameObject")]
    public GameObject ToolTipGameObject;

}
