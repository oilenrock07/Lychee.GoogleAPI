using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using Lychee.GoogleAPI.Common.Interfaces;
using Lychee.GoogleAPI.Sheet.Interfaces;

namespace Lychee.GoogleAPI.Sheet
{
    public class GoogleSheetService : IGoogleSheetService
    {
        private const string CredPath = "token.json";

        public virtual IList<IList<object>> ReadData(IGoogleSheetRequest configRequest)
        {
            UserCredential credential;
            using (var stream =  new FileStream(configRequest.Credentials, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    configRequest.Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(CredPath, true)).Result;
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = configRequest.ApplicationName,
            });

            var request = service.Spreadsheets.Values.Get(configRequest.SpreadSheetId, configRequest.Range);

            var response = request.Execute();
            return response.Values;
        }
    }
}
