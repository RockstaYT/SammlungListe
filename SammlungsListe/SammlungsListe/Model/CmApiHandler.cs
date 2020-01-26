namespace SammlungsListe.Model
{
    using CMApiResolve;
    using System.Xml;

    public class CmApiHandler
    {
        private main cMApiResolve;
        private XmlHandler xmlHandler;
        public CmApiHandler()
        {
            cMApiResolve = new main();
            xmlHandler = new XmlHandler();
        }

        public void GetSinglesFromEditionNoDetails(string idExpansion)
        {
            XmlDocument response = cMApiResolve.GetSinglesNoDeatails(idExpansion);
            xmlHandler.SaveSingles(response);
        }
    }
}
