using System.Xml;

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



            // Open Xml Document? read and remove Eleement

            //XmlDocument document = new XmlDocument();
            //document.Load("users.xml");

            //XmlNode? node = document.SelectSingleNode("//City");
            //Console.WriteLine(node?.InnerText);
            //XmlNode? nodeParent = node?.ParentNode;
            //Console.WriteLine(nodeParent?.Name);
            //nodeParent?.RemoveChild(node!);

            //document.Save("users.xml");
        }
    }
}