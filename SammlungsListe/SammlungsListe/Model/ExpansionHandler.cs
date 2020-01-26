namespace SammlungsListe.Model
{
    using System.Collections.Generic;
    using System.Xml;

    public class ExpansionHandler
    {
        public List<string> GetExpansions(Dictionary<string, string> ExpansionDictionary)
        {
            List<string> Expansions = new List<string>();

            foreach (var key in ExpansionDictionary.Keys)
            {
                Expansions.Add(key.ToString());
            }
            Expansions.Sort();

            return Expansions;
        }

        public Dictionary<string, string> GetExpansionsDictionary(Dictionary<string, XmlDocument> xmlDocuments)
        {
            Dictionary<string, string> ExpansionDictionary = new Dictionary<string, string>();
            XmlDocument expansionDocument = new XmlDocument();

            xmlDocuments.TryGetValue("Expansions.xml", out expansionDocument);

            foreach (XmlNode Node in expansionDocument.SelectNodes("/Expansions/Expansion"))
            {
                if (Node.Name == "Expansion")
                {
                    string EnName = Node.SelectSingleNode("EnName").InnerXml;
                    string IdExpansion = Node.SelectSingleNode("IdExpansion").InnerXml;

                    ExpansionDictionary.Add(EnName, IdExpansion);
                }
            }

            return ExpansionDictionary;
        }

        public string GetExpansionId(string ExpansionName, Dictionary<string, string> Expansions)
        {
            string ExpansionId = Expansions[ExpansionName];

            return ExpansionId;
        }
    }
}
