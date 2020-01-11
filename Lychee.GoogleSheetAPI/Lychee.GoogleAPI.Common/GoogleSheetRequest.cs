using Lychee.GoogleAPI.Common.Interfaces;

namespace Lychee.GoogleAPI.Common
{
    public class GoogleSheetRequest : IGoogleSheetRequest
    {
        public string ApplicationName { get; set; }
        public string SpreadSheetId { get; set; }
        public string Range { get; set; }
        public string[] Scopes { get; set; }
        public string Credentials { get; set; }
    }
}
