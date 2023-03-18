using System;

namespace App.Models
{
    // ErrorView model defines properties and methods related to error handling 
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
