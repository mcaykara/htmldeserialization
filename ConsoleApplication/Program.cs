using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XmlModel;

namespace ConsoleApplication {
    class Program {
        static void Main(string[] args) {
            var xmlModel = getXmlModel();
            var persons = mapModel(xmlModel);

            foreach (var person in persons) {
                Console.WriteLine($"{person.FirstName} {person.LastName} {person.PhoneNumber}");
            }
        }


        static HtmlContent getXmlModel() {
            //var xml = new HtmlContent();
            var fileName = "file.html";
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var path = Path.Combine(folder, fileName);

            return load<HtmlContent>(path);
        }


        static IList<Person> mapModel(HtmlContent xmlModel) {
            var rows = xmlModel.Body.Table.TableBody.Rows;
            var dtos = new List<Person>(rows.Count);

            foreach (var item in rows) {
                var dto = new Person();

                for (int i = 0; i < item.Cells.Count; i++) {
                    var cell = item.Cells[i];

                    switch (i) {
                        case 0:
                            dto.Id = Convert.ToInt32(cell);
                            break;
                        case 1:
                            dto.FirstName = cell;
                            break;
                        case 2:
                            dto.LastName = cell;
                            break;
                        case 3:
                            dto.PhoneNumber = cell;
                            break;
                        case 4:
                            dto.EMailAddress = cell;
                            break;
                        case 5:
                            dto.Debit = Convert.ToDecimal(cell);
                            break;
                        default:
                            break;
                    }

                }
                dtos.Add(dto);
            }

            return dtos;
        }



        public static T load<T>(string fileName) {
            Object rslt;

            if (File.Exists(fileName)) {
                var xs = new XmlSerializer(typeof(T));

                using (var sr = new StreamReader(fileName)) {
                    rslt = (T)xs.Deserialize(sr);
                }
                return (T)rslt;
            } else {
                return default(T);
            }
        }
    }
}
