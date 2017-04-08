using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipSystem : MonoBehaviour {

    public GameObject TipFullPanel;
    public Text text;
       

    protected virtual void Start() {

    }

    public virtual void Show(string tip) {
        TipFullPanel.SetActive(true);
        text.text = tip;
    }
    public virtual void Back() {
        TipFullPanel.SetActive(false);
        text.text = "";
    }

}
