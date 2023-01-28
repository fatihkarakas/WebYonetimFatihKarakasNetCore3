using System;

namespace WebYonetimFatihKarakasNetCore3.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string ErrMessage { get; set; }
    }
}
