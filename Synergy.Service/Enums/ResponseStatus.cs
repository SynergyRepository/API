using System;
using System.Collections.Generic;
using System.Text;

namespace Synergy.Service.Enums
{
    public enum ResponseStatus
    {
        Success = 1,
        ServerError,
        NotFound,
        Conflict,
        Unauthorized,
        AwaitingVerification,
        UnSupportedFileFormat,
        BadRequest,
        NoContent,
        AwaitingCompletion
    }
}
