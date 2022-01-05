using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    /// <summary>
    /// User verification
    /// </summary>
    public enum UserVerificationStatus
    {
        Verified = 0,
        InProcess,
        Unverified,
        Banned
    }
}
