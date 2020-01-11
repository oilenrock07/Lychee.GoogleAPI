using System;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Sheets.v4;
using Lychee.GoogleAPI.Common;
using Lychee.GoogleAPI.Sheet;
using NUnit.Framework;

namespace Lychee.GoogleAPITest
{
    [TestFixture]
    public class GoogleSheetTest
    {
        [Test]
        public void CanReadData()
        {
            //Arrange
            var watchList = new List<StockWatchList>();
            var service = new GoogleSheetService();
            var credentialConfig = $"{Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)}/debug/credentials.json";
            var request = new GoogleSheetRequest
            {
                Range = "Sheet1!A2:F",
                SpreadSheetId = "1gPXVVkqWfFsW4utuJjo-qQRblSZ6-H7CyYN8WHfUxVk",
                ApplicationName = "StockWatchList",
                Scopes = new []{ SheetsService.Scope.SpreadsheetsReadonly },
                Credentials = credentialConfig
            };
            
            //Act
            var values = service.ReadData(request);
            if (values != null && values.Count > 0)
            {
                //Loop each row
                foreach (var row in values)
                {
                    watchList.Add(new StockWatchList
                    {
                        StockCode = row[0].ToString(),
                        Entry = Convert.ToDecimal(row[1]),
                        DateEntered = Convert.ToDateTime(row[5])
                    });
                }
            }

            //Asserts
            Assert.That(watchList, Is.Not.Null);
            Assert.That(watchList.Count, Is.GreaterThan(0));
        }
    }
}
