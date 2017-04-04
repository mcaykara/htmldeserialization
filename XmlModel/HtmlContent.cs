using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlModel {
    [XmlRoot(ElementName = "html")]
    public class HtmlContent {
        [XmlElement(ElementName = "body")]
        public Body Body { get; set; }




    }

    public class Body {
        [XmlElement(ElementName = "table")]
        public Table Table { get; set; }



    }

    public class Table {
        [XmlElement(ElementName = "thead")]
        public TableHeader TableHeader { get; set; }


        [XmlElement(ElementName = "tbody")]
        public TableBody TableBody { get; set; }
    }


    public class TableHeader {
        [XmlElement(ElementName = "tr")]
        public List<HeaderRow> Rows { get; set; }


        public class HeaderRow {
            [XmlElement(ElementName = "th")]
            public List<string> Cells { get; set; }
        }
    }


    public class TableBody {
        [XmlElement(ElementName = "tr")]
        public List<BodyRow> Rows { get; set; }


        public class BodyRow {
            [XmlElement(ElementName = "td")]
            public List<string> Cells { get; set; }
        }
    }
}