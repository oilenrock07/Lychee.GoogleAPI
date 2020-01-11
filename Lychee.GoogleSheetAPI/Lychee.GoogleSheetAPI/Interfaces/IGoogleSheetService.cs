using System.Collections.Generic;
using Lychee.GoogleAPI.Common.Interfaces;

namespace Lychee.GoogleAPI.Sheet.Interfaces
{
    public interface IGoogleSheetService
    {
        IList<IList<object>> ReadData(IGoogleSheetRequest configRequest);
    }
}
