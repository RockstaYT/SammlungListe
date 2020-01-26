namespace SammlungsListe.Model
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using OwnProperties;
    public class XmlHandler
    {
        private string path = "./";        

        private string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public Dictionary<string, XmlDocument> GetXml(string path, bool isFolder)
        {
            XmlDocument xmlDocument = new XmlDocument();
            Dictionary<string, XmlDocument> xmlList = new Dictionary<string, XmlDocument>();

            Path = path;

            if(isFolder)
            {
                xmlList = GetXmlFiles();
            }
            else
            {
                xmlList = GetXmlFile();
            }

            return xmlList;
        }

        public void SaveSingles(XmlDocument singles)
        {            
            XmlNode expansioInfo = singles.SelectSingleNode("/response/expansion");

            XmlDocument expansionXml = new XmlDocument();
            string enName = expansioInfo.SelectSingleNode("enName").InnerText;
            enName = enName.Replace(":", "");
            string enNameNoSpace = enName.Replace(" ", "");
            XmlNode root = expansionXml.CreateElement("A" + enNameNoSpace);

            expansionXml.AppendChild(root);

            XmlElement language = expansionXml.CreateElement("language");

            foreach (XmlNode localization in singles.SelectNodes("/response/expansion/localization"))
            {
                language.InnerText += ";" + localization.SelectSingleNode("languageName").InnerText;
            }

            root.AppendChild(language);

            foreach (XmlNode single in singles.SelectNodes("/response/single"))
            {
                XmlElement singleCard = expansionXml.CreateElement("singleCard");
                XmlElement enCardName = expansionXml.CreateElement("enCardName");
                XmlElement cardId = expansionXml.CreateElement("cardId");
                XmlElement priceLow = expansionXml.CreateElement("priceLow");
                XmlElement priceMid = expansionXml.CreateElement("priceMid");
                XmlElement cardCount = expansionXml.CreateElement("cardCount");

                enCardName.InnerText = single.SelectSingleNode("enName").InnerText;
                cardId.InnerText = single.SelectSingleNode("idProduct").InnerText;
                cardCount.InnerText = "0";

                singleCard.AppendChild(enCardName);
                singleCard.AppendChild(cardId);
                singleCard.AppendChild(priceLow);
                singleCard.AppendChild(priceMid);
                singleCard.AppendChild(cardCount);

                root.AppendChild(singleCard);
            }

            expansionXml.Save("./Expansions/" + enName + ".xml");
        }

        public List<Expansion> LoadSingles()
        {
            string path = "./Expansions";
            List<SingleCard> singleCard = new List<SingleCard>();
            List<Expansion> expansions = new List<Expansion>();

            foreach (string expansionFile in Directory.GetFiles(path))
            {
                string fileName = expansionFile.Replace(path + "\\", "");
                string ExpansionName = fileName.Replace(".xml", "");
                string ExpansionNoSpace = "A" + ExpansionName.Replace(" ", "");
                XmlDocument expansionDoument = new XmlDocument();
                expansionDoument.Load(expansionFile);

                singleCard = GetSingles(expansionDoument, ExpansionNoSpace);

                Expansion expansion = new Expansion(ExpansionName, singleCard, GetExpansionLanguage(expansionDoument, ExpansionNoSpace));

                expansions.Add(expansion);
            }

            return expansions;
        }

        //Path must be an Folder
        private Dictionary<string, XmlDocument> GetXmlFiles()
        {
            Dictionary<string, XmlDocument> xmlList = new Dictionary<string, XmlDocument>();

            string currentDirectory = Directory.GetCurrentDirectory();

            string[] xmlFiles = Directory.GetFiles(Path, "*.xml", SearchOption.TopDirectoryOnly);

            foreach (string file in xmlFiles)
            {
                string fileName = file.Remove(0, 2);
                xmlList.Add(fileName, ReadXmlFile(file));
            }
                       
            return xmlList;
        }

        private Dictionary<string, XmlDocument> GetXmlFile()
        {
            throw new System.ArgumentException("this path is programmed yet");
            Dictionary<string, XmlDocument> xmlList = new Dictionary<string, XmlDocument>();
            return xmlList;
        }

        private XmlDocument ReadXmlFile(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            return xmlDocument;
        }

        private List<SingleCard> GetSingles(XmlDocument xmlDocument, string ExpansionNoSpace)
        {
            List<SingleCard> singleCards = new List<SingleCard>();

            foreach(XmlNode singleCardInfo in xmlDocument.SelectNodes(ExpansionNoSpace + "/singleCard"))
            {
                string enCardName = singleCardInfo.SelectSingleNode("enCardName").InnerText;
                string cardId = singleCardInfo.SelectSingleNode("cardId").InnerText;
                string priceLow = singleCardInfo.SelectSingleNode("priceLow").InnerText;
                string priceMid = singleCardInfo.SelectSingleNode("priceMid").InnerText;
                string cardCount = singleCardInfo.SelectSingleNode("cardCount").InnerText;

                SingleCard singleCard = new SingleCard(enCardName, cardId, priceLow, priceMid, cardCount);
                singleCards.Add(singleCard);
            }

            return singleCards;
        }

        private List<string> GetExpansionLanguage(XmlDocument xmlDocument, string expansionName)
        {
            XmlNode xmlNode = xmlDocument.SelectSingleNode("/" + expansionName + "/language");

            string languages = xmlNode.InnerText;

            string[] language = languages.Split(';');
            List<string> ExpansionLanguages = language.Skip(1).ToList();
            return ExpansionLanguages;
        }
    }
}
