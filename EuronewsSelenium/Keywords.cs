namespace EuronewsSelenium
{
    public class Keywords
    {
        public string _xPath;
        public string _titleName;
        public string _urlName;

        public Keywords(string xPath, string titleName, string urlName) {

            _xPath = xPath;
            _titleName = titleName;
            _urlName = urlName;
        }   

        public override string ToString()
        {
            return $"{_xPath},{_titleName},{_urlName}";
        }

       
    }
}
