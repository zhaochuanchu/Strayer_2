using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public static class XMLHelper {

    /// <summary>
    /// 加载xml
    /// </summary>
    /// <param name="xmlName">xml的文件名(xxx.xml)</param>
    public static XmlDocument LoadXML(string xmlName) {
        //string path = Resources.Load(xmlName).ToString();//用Resources读取的方法好使了 不能带后缀名
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取
        xml.Load(XmlReader.Create(Application.dataPath+ "/StreamingAssets/" + xmlName, set));
        return xml;
    }

}
