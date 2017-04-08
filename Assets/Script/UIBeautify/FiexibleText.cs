using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

/// <summary>
/// 性能堪忧
/// </summary>
public class FiexibleText : MonoBehaviour {

    [Tooltip("对话滚动时间")][Range(1,10)]
    /// <summary>
    /// 对话滚动时间
    /// </summary>
    public int FlowDuration = 2;

    [Tooltip("变化大小比例")][Range(1f, 2f)]
    /// <summary>
    /// 变化大小比例
    /// </summary>
    public float ratio = 1.5f;



    private Text text;
    private string content;
    private char[] array;
    private int length;
    private int cursor;//计数器
    private int timer;//计时器

    private int minSize;
    private int maxSize;

    private bool isClick = false;

    protected virtual void Awake() {
        text = GetComponent<Text>();
        content = text.text + "          ";
        array = content.ToCharArray();
        length = content.Length;
        text.text = "";
        cursor = 0;
        timer = 0;
        minSize = text.fontSize;
        maxSize = (int)(text.fontSize * ratio);
    }

    protected virtual void FixedUpdate() {
        if (cursor <= length && timer % FlowDuration == 0 && !isClick) {
            string temp = "";
            for (int i = 0; i < cursor; i++) {
                char c = array[i];
                int size = ((maxSize - cursor + i) >= minSize) ? (maxSize - cursor + i) : minSize;
                if (c.ToString() == " " && (length - i) < 11) { size = minSize; }
                temp += "<size=" + size + ">" + c.ToString() + "</size>";
            }
            text.text = temp;
            cursor++;
        }
        timer++;
    }

    public virtual void OnPointerClick(PointerEventData eventData) {
        isClick = true;
        text.text = content;
        text.fontSize = minSize;
    }

}
