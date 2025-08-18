using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rcbi.AspNetCore.Helper.Ftp
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }
}
