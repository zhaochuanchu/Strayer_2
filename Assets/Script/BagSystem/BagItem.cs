using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagItem : MonoBehaviour,IDropHandler {

    public virtual void OnDrop(PointerEventData eventData) {
        eventData.pointerDrag.transform.parent.GetComponent<Canvas>().sortingOrder = BagSystem.instance.defaultSortingOrder;
        eventData.pointerDrag.transform.SetParent(this.transform);
        eventData.pointerDrag.transform.localPosition = new Vector3(0, 0, 0);
    }


}
