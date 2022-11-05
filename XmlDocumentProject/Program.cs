using System.Xml;
using System.Xml.Linq;

namespace XmlDocumentProject
{
    class Address
    {
        public string? City { set; get; }
        public string? Street { set; get; }
    }
    class User
    {
        public string? Name { set; get; }
        public int Age { set; get; }
        public Address? Address { set; get; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new()
            {
                Name = "Bob",
                Age = 24,
                Address = new() { City = "Moscow", Street = "Tverskaya" }
            };



            // Create XmlDocument

            //XmlDocument document = new XmlDocument();

            //XmlElement elemRoot = document.CreateElement("Users");
            //document.AppendChild(elemRoot);

            //// create elements
            //XmlElement xmlUser = document.CreateElement(nameof(User));
            //XmlElement xmlName = document.CreateElement(nameof(User.Name));
            //XmlElement xmlAge = document.CreateElement(nameof(User.Age));

            //// element Name innertext and attribute
            //XmlText xmlNameText = document.CreateTextNode(user.Name);
            //xmlName.AppendChild(xmlNameText);
            //XmlAttribute xmlNameAttr = document.CreateAttribute("Type");
            //xmlNameAttr.Value = "First";
            //xmlName.Attributes.Append(xmlNameAttr);

            //// element Age innertext
            //xmlAge.InnerText = user.Age.ToString();

            //// append element in element User
            //xmlUser.AppendChild(xmlName);
            //xmlUser.AppendChild(xmlAge);

            //// append element User in Root
            //elemRoot.AppendChild(xmlUser);

            //XmlElement xmlAddress = document.CreateElement(nameof(Address));
            //XmlElement xmlCity = document.CreateElement(nameof(Address.City));
            //XmlElement xmlStreet = document.CreateElement(nameof(Address.Street));

            //xmlCity.InnerText = user.Address.City;
            //xmlStreet.InnerText = user.Address.Street;

            //xmlUser.AppendChild(xmlAddress);

            //xmlAddress.AppendChild(xmlCity);
            //xmlAddress.AppendChild(xmlStreet);

            //document.Save("users.xml");



            //Open Xml Document? read and remove Eleement

            //XmlDocument document = new XmlDocument();
            //document.Load("users.xml");

            //var nodes = document.DocumentElement.SelectNodes("//*[@Type=\"Last\"]");
            ////Console.WriteLine(node?.InnerText);
            ////XmlNode? nodeParent = node?.ParentNode;
            //foreach(XmlNode item in nodes)
            //{
            //    //var attr = item.SelectNodes("@+");
            //    //Console.WriteLine(attr);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.InnerText);
            //    Console.WriteLine(item.InnerXml);
            //}

            //nodeParent?.RemoveChild(node!);

            //document.Save("users.xml");


            //XDocument xDocument = new();
            //xDocument.Add(new XElement("Users"));
            //XElement xUser = new(nameof(User));
            //XElement xName = new(nameof(User.Name), user.Name);
            //XAttribute xType = new("Type", "First");
            //xName.Add(xType);
            //xUser.Add(xName);
            //xUser.Add(new XElement(nameof(User.Age), user.Age));

            //xDocument.Root.Add(xUser);


            //XDocument xDocument = new XDocument(
            //                         new XElement("Users",
            //                            new XElement(nameof(User),
            //                                new XElement(nameof(User.Name), user.Name, 
            //                                    new XAttribute("Type", "First")
            //                                ),
            //                                new XElement(nameof(User.Age), user.Age),
            //                                new XElement(nameof(Address),
            //                                    new XElement(nameof(Address.City), user.Address.City),
            //                                    new XElement(nameof(Address.Street), user.Address.Street)
            //                                )
            //                            )
            //                         )
            //                      );
            //xDocument.Save("usersLinq.xml");


            XDocument document = XDocument.Load("users.xml");
            XElement? root = document.Root;

            //foreach(XElement element in root.Elements("User"))
            //{
            //    Console.WriteLine($"Name: {element.Element("Name").Value}");
            //    Console.WriteLine($"Age: {element.Element("Age").Value}");
            //    Console.WriteLine();
            //}

            var users = document.Element("Users")
                                .Elements("User")
                                .Where(u => u.Element("Address").Element("City")?.Value == "Moscow")
                                .Select(u => new
                                {
                                    Name = u.Element("Name")?.Value,
                                    Type = u.Element("Name").Attribute("Type")?.Value,
                                    Age = u.Element("Age")?.Value,
                                    City = u.Element("Address").Element("City")?.Value,
                                    Street = u.Element("Address").Element("Street")?.Value
                                });

            foreach(var u in users)
            {
                Console.WriteLine($"[{u.Type}] {u.Name} ({u.Age}) -> {u.City} / {u.Street}");
            }

        }
    }
}