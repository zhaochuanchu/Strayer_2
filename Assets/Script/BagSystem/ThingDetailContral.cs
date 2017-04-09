using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThingDetailContral : MonoBehaviour {

    [SerializeField]private GameObject Image;
    [SerializeField]private GameObject Name;
    [SerializeField]private GameObject DetailText;
    [SerializeField]private GameObject AmountText;
    [SerializeField]private GameObject DescribeText;

    protected virtual void Awake() {

    }

    public virtual void SetText(ThingBaseInfo info, string count) {
        //"<color="+ ColorUtility.ToHtmlStringRGBA(countColor) + ">" + "xxx" + "</color>";
        Name.GetComponent<Text>().text = info.Name;
        DetailText.GetComponent<Text>().text = info.Detail;
        AmountText.GetComponent<Text>().text = "Num:"+count;
        DescribeText.GetComponent<Text>().text = info.Describe;
    }

}
