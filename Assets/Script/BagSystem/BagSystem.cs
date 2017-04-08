using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

//拾取,丢弃等操作在此类中设计
public class BagSystem : MonoBehaviour,IKey {

    public const int MaxMount = 16;

    public readonly int defaultSortingOrder = 1;

    public static BagSystem instance;

    //string-id GameObject-Thing的引用
    private Dictionary<string, GameObject> ThingsDictionary=new Dictionary<string, GameObject>();

    [SerializeField]private KeyCode keycode=KeyCode.B;

    public  GameObject BagThingDetailView;
    public GameObject BagFullPanel;
    public GameObject ThingPrefeb;
    public bool isDrag = false;

    public GameObject NextItem {
        get {
            GameObject BagItemsPanel = BagFullPanel.transform.FindChild("BagPanel").gameObject;
            foreach(Transform child in BagItemsPanel.transform) {
                if (child.transform.childCount == 0) {
                    return child.gameObject;
                }
            }
            throw new System.Exception("背包已满");
        }
    }

    protected virtual void Awake() {
        if (instance == null)
            instance = this;
        else throw new System.Exception("单例状态破坏");
    }

    protected virtual void Update() {
        if (Input.GetKeyDown(keycode)&&!isDrag) {
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
        BagThingDetailView.SetActive(false);
        BagFullPanel.SetActive(!BagFullPanel.activeInHierarchy);
    }
    
    public virtual void AddAThing(string id) {
        if (ThingsDictionary.ContainsKey(id)) {
            ThingsDictionary[id].GetComponent<Thing>().Amount++;
        }
        else {
            GameObject newThing = GameObject.Instantiate(ThingPrefeb);
            newThing.GetComponent<Thing>().SetThingInfo(GetThingInfoFromXml(id));
            ThingsDictionary.Add(id, newThing);
            newThing.transform.SetParent(NextItem.transform);
            newThing.transform.localPosition = Vector3.zero;
        }
    }
    public virtual void DropAThing() {

    }
    public virtual ThingBaseInfo GetThingInfoFromXml(string id) {
        XmlDocument xml = XMLHelper.LoadXML("ThingsInfo.xml");
        //XmlNodeList xmlNodeList = xml.SelectSingleNode("ThingsInfo").ChildNodes;
        XmlNodeList xmlNodeList = xml.DocumentElement.ChildNodes;
        foreach (XmlElement element in xmlNodeList) {
            if (element.GetAttribute("id") == id) {
                string detail="error", describe="error";
                foreach (XmlElement childElement in element.ChildNodes) {
                    if (childElement.Name == "detail")
                        detail = childElement.FirstChild.Value;
                    //需要注意 detail的值在它的子节点上!!!
                    else if (childElement.Name == "describe")
                        describe = childElement.FirstChild.Value;
                }
                return new ThingBaseInfo(id, element.GetAttribute("name"), detail,describe);
            }
        }
        throw new System.Exception("未找到该物体");
    }

}
