using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingBaseInfo {

    public string ID { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Describe { get; set; }

    public ThingBaseInfo(string id,string name,string detail,string describe) {
        this.ID = id;
        this.Name = name;
        this.Detail = detail;
        this.Describe = describe;
    }
    public ThingBaseInfo() { }

}
