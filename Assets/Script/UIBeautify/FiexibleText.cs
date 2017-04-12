using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;

[RequireComponent(typeof(Text))]
public class FiexibleText : MonoBehaviour,IPointerClickHandler {

    /// <summary>对话滚动时间</summary>
    [Tooltip("对话滚动延迟时间")][Range(0, 0.05f)]
    public float FlowDuration = 0.02f;

    /// <summary>变化大小比例</summary>
    [Tooltip("变化大小比例")][Range(1f, 2f)]
    public float ratio = 1.5f;

    private StringBuilder WholeString;
    private Text text;
    private int cursor = 0;
    private int minSize;
    private int maxSize;

    protected virtual void Awake() {
        text = GetComponent<Text>();
        text.supportRichText = true;
        string fillSpace = "          ";
        WholeString = new StringBuilder(text.text+ fillSpace, 0, 
            text.text.Length+fillSpace.Length, text.text.Length+fillSpace.Length);
        minSize = text.fontSize;
        maxSize = (int)(text.fontSize * ratio);
    }
    protected virtual void Start() {
        StartCoroutine(Show());
    }
    //使用字符串作为参数可以开启线程并在线程结束前终止线程，
    //相反使用IEnumerator作为参数只能等待线程的结束而不能随时终止
    //(除非使用StopAllCoroutines()方法)
    public virtual void OnPointerClick(PointerEventData eventData) {
        StopAllCoroutines();
        text.text = WholeString.ToString();
    }
    /// <summary>使用StringBuilder的性能更好</summary>
    protected virtual IEnumerator Show() {
        StringBuilder Builder = new StringBuilder("", 0, 0, WholeString.Length + 200);
        StringBuilder tempCharBuilder = new StringBuilder(" ".ToString(), 0, 1, 17);
        for (int i = 0; i < WholeString.Length; i++) {
            Builder.Length = 0;
            for (int j = 0; j < cursor; j++) {
                tempCharBuilder.Length = 1;
                tempCharBuilder[0] = WholeString[j];
                if ((maxSize - cursor + j) > minSize)
                    tempCharBuilder.Insert(0, "<size=" + (maxSize - cursor + j).ToString() + ">").Append("</size>"); 
                Builder.Append(tempCharBuilder.ToString());
            }
            text.text = Builder.ToString();
            cursor++;
            yield return new WaitForSeconds(FlowDuration);
        }
    }
}
