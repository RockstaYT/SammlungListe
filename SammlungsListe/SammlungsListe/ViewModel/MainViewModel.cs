namespace SammlungsListe.ViewModel
{
    using Model;
    using SammlungsListe.OwnProperties;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Xml;

    public class MainViewModel : INotifyPropertyChanged
    {
        /*Class Variables*/
        private XmlHandler xmlHandler;
        private ExpansionHandler expansionHandler;
        private CmApiHandler cmApiHandler;
        private Dictionary<string, XmlDocument> xmlDocument;
        private Dictionary<string, string> expansions;
        private List<string> expansionNames;
        private string selectedExpansion;
        private string selectedExpanisonId;
        private string consoleOutput;
        private ICommand getSinglesClicked;
        private List<Expansion> downloadedExpansions;
        private List<string> languages;
        private Visibility visibility;
        private string selectedCardId;
        private List<string> selectedExpansionLanguage;


        public event PropertyChangedEventHandler PropertyChanged;

        /*Constructor*/
        public MainViewModel()
        {
            xmlHandler = new XmlHandler();
            expansionHandler = new ExpansionHandler();
            cmApiHandler = new CmApiHandler();

            ConsoleOutput += "Startup";

            ConsoleOutput += "Read expansion file";
            ReadXmlFiles("./", true);

            ConsoleOutput += "Load expansions in dictionary";
            GetExpansionDictionary();

            ConsoleOutput += "Load singles";
            LoadSingles();

            ConsoleOutput += "Load expansions in list";
            UpdateExpansions();

            List<string> lang = new List<string>(); // need to change
            lang.Add("English");

            Visibility = Visibility.Hidden;
        }

        /*Properties*/
        private Dictionary<string, XmlDocument> XmlDocument
        {
            get
            {
                return xmlDocument;
            }
            set
            {
                xmlDocument = value;
            }
        }

        private Dictionary<string, string> Expansions
        {
            get
            {
                return expansions;
            }
            set
            {
                expansions = value;
            }
        }

        public List<string> ExpansionNames
        {
            get
            {
                return expansionNames;
            }

            set
            {
                expansionNames = value;
                OnPropertyChanged("ExpansionNames");
            }
        }

        public string SelectedExpansion
        {
            get
            {
                return selectedExpansion;
            }
            set
            {
                selectedExpansion = value;
                SetSelectedExpansionID();
                SetSelectedExpansionLanguage();
                Visibility = Visibility.Visible;
                ConsoleOutput += "Selected expansion changed";
                OnPropertyChanged("SelectedExpansion");                
            }
        }

        public ICommand GetSinglesClicked
        {
            get
            {
                return getSinglesClicked ?? (getSinglesClicked = new CHandler(() => GetSinglesFromExpansion()));
            }
        }

        public string SelectedExpanisonId
        {
            get
            {
                return selectedExpanisonId;
            }
            set
            {
                selectedExpanisonId = value;
                OnPropertyChanged("SelectedExpanisonId");
            }
        }

        public List<Expansion> DownloadedExpansions
        {
            get
            {
                return downloadedExpansions;
            }
            set
            {
                downloadedExpansions = value;
            }
        }

        public string ConsoleOutput
        {
            get
            {
                return consoleOutput;
            }
            set
            {
                consoleOutput = value + "\n";
                OnPropertyChanged("ConsoleOutput");
            }
        }

        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        public List<string> SelectedExpansionLanguage
        {
            get
            {
                return selectedExpansionLanguage;
            }
            set
            {
                selectedExpansionLanguage = value;
                OnPropertyChanged("SelectedExpansionLanguage");
            }
        }

        //Stores the id of the selected card
        public string SelectedCardId
        {
            get
            {
                return selectedCardId;
            }
            set
            {
                selectedCardId = value;
                OnPropertyChanged("SelectedCardId");
            }
        }


        /*Private Funktions*/
        private void SetSelectedExpansionID()
        {
            if(ExpansionNames.Contains(SelectedExpansion))
            {
                SelectedExpanisonId = expansionHandler.GetExpansionId(SelectedExpansion, Expansions);
                ConsoleOutput += "Expansion id set";
            }
        }

        private void SetSelectedExpansionLanguage()
        {
            foreach(Expansion expansion in DownloadedExpansions)
            {
                if(expansion.ExpansionName.Equals(SelectedExpansion))
                {
                    SelectedExpansionLanguage = expansion.Languages;
                }
            }
        }

        private void GetExpansionDictionary()
        {
            Expansions = expansionHandler.GetExpansionsDictionary(XmlDocument);
        }

        private void LoadSingles()
        {
            DownloadedExpansions = xmlHandler.LoadSingles();
            ConsoleOutput += "Get all singles in expansions";
        }

        private void ReadXmlFiles(string path, bool isFolder)
        {
            XmlDocument = xmlHandler.GetXml(path, isFolder);
        }

        private void UpdateExpansions()
        {
            ExpansionNames = expansionHandler.GetExpansions(Expansions);
        }

        private void GetSinglesFromExpansion()
        {
            cmApiHandler.GetSinglesFromEditionNoDetails(SelectedExpanisonId);
            ConsoleOutput += "Download singles from cm";
            LoadSingles();
        }

        private void SearchCard()
        {
            //get expansion
            //get card
            //get card info into property(id, Language, image)
        }


        /*On property changed*/
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
