namespace Lychee.GoogleAPI.Common.Interfaces
{
    public interface IGoogleSheetRequest
    {
        string ApplicationName { get; set; }
        string SpreadSheetId { get; set; }
        string Range { get; set; }
        string[] Scopes { get; set; }

        /// <summary>
        /// Full filename of the credentials.json including the path
        /// </summary>
        string Credentials { get; set; }
    }
}
