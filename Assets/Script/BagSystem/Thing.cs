using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
public class Thing : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler,
    IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public bool AutoInitialize = false;
    private ThingBaseInfo ThingInfo=new ThingBaseInfo();

    private int amount = 1;

    [Space(10)]

    [Header("临时初始化ThingInfo")]
    public string ID;
    public string Name;
    [TextArea]public string Detail;
    [Range(1, 99)]public int temp_amount = 1;
    [TextArea]public string Describe;

    [ContextMenu("Initialize")] 
    private void InitaializeThingInfo() {
        ThingInfo = new ThingBaseInfo(ID, Name, Detail,Describe);
        Amount = temp_amount;
    }

    /********辅助字段*****/
    private Vector3 preMouseWorldPosition;
    private GameObject AmountText;

    public virtual int Amount {
        get { return amount; }
        set {
            amount = value;
            AmountText.GetComponent<Text>().text = value.ToString();

        }
    }

    protected virtual void Awake() {
        AmountText = transform.FindChild("Amount").gameObject;
        if (AutoInitialize)
            InitaializeThingInfo();
    }
    protected virtual void Update() {
    }

    public void SetThingInfo(ThingBaseInfo ThingInfo) {
        this.ThingInfo = ThingInfo;
    }

    public virtual void OnBeginDrag(PointerEventData eventData) {
        BagSystem.instance.isDrag = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.parent.GetComponent<Canvas>().sortingOrder = BagSystem.instance.defaultSortingOrder + 1;
        this.transform.position = eventData.position;//MD 我被颠覆了
        //并缩放一半
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public virtual void OnDrag(PointerEventData eventData) {
        this.transform.position = eventData.position;//MD 我被颠覆了
    }

    public virtual void OnEndDrag(PointerEventData eventData) {
        this.transform.localScale = new Vector3(1, 1, 1);
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.transform.localPosition = new Vector3(0, 0, 0);
        BagSystem.instance.isDrag = false;
    }

    public virtual void OnDrop(PointerEventData eventData) {
        eventData.pointerDrag.transform.parent.GetComponent<Canvas>().sortingOrder = BagSystem.instance.defaultSortingOrder;
        Transform temp = eventData.pointerDrag.transform.parent;
        eventData.pointerDrag.transform.SetParent(this.transform.parent);
        this.transform.SetParent(temp);
        this.transform.localPosition = new Vector3(0, 0, 0);
    }

    public virtual void OnPointerEnter(PointerEventData eventData) {
        GameObject detailView = BagSystem.instance.BagThingDetailView;
        detailView.SetActive(true);
        detailView.GetComponent<ThingDetailContral>().SetText(ThingInfo, Amount.ToString());
        detailView.GetComponent<Canvas>().overrideSorting = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData) {
        BagSystem.instance.BagThingDetailView.SetActive(false);
    }

}
