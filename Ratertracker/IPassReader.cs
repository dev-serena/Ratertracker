using System;
using System.Collections.Generic;


namespace Ratertracker
{
    interface IPassReader
    {

        IEnumerable<CredentialModel> ReadPasswords();
        string BrowserName { get; }

    }
}
