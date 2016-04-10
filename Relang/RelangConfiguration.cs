using System.Xml.Serialization;

namespace Relang
{
    public class RelangConfiguration
    {
        [XmlElement(ElementName="Folder")]
        string RFolder { get; set; }

        [XmlElement(ElementName="Path")]
        string RPath { get; set; }


    }
}
