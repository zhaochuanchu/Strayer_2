using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPickUpSystem : MonoBehaviour, IKey,IBanedScripts {

    [SerializeField]private KeyCode keycode = KeyCode.E;
    //public event Action<int> PickUpSomething;//不适合用事件机制
    [HideInInspector]public GameObject WaitingThingObject = null;

    protected virtual void Update() {
        if (Input.GetKeyDown(keycode) && WaitingThingObject != null) {
            ResponseKey();
        }
    }

    public virtual void SetKeyCode(KeyCode keycode) {
        this.keycode = keycode;
    }
	public virtual KeyCode GetKeyCode() {
        return keycode;

    }

    public virtual void ResponseKey() {
        BagSystem.instance.AddAThing(WaitingThingObject.GetComponent<ThingContral>().ThingId);
        GetComponent<PlayerStateContral>().GamingCanvas.GetComponent<TipSystem>().Back();
        Destroy(WaitingThingObject);
        WaitingThingObject = null;
    }

}
