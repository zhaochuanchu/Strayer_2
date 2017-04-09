using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class ThingContral : HighlighterController {

    public string ThingId;
    private const string TipPickUp = "Press E to pick up";

    protected override void Start() {
        base.Start();
    }

    protected virtual void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerPickUpSystem>().WaitingThingObject = this.gameObject;
            collider.gameObject.GetComponent<PlayerStateContral>().GamingCanvas.
                GetComponent<TipSystem>().Show(TipPickUp);
            GetComponent<Highlighter>().ConstantOn(Color.blue);
        }
    }
    protected virtual void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            collider.gameObject.GetComponent<PlayerPickUpSystem>().WaitingThingObject = null;
            collider.gameObject.GetComponent<PlayerStateContral>().GamingCanvas.
                GetComponent<TipSystem>().Back();
            GetComponent<Highlighter>().ConstantOff();
        }
    }

}
