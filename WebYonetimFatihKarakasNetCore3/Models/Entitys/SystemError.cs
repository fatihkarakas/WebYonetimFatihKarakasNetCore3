using System;

namespace KarakasWenAdmin.Models.Entitys
{
    public class SystemError
    {
        public int Id { get; set; }
        public string ShortMessage { get; set; } = "";
        public string FullMessage { get; set; } = "";
        public string IpAddress { get; set; } = string.Empty;
        public string PageUrl { get; set; }  = string.Empty ;
        public string ReferrerUrl { get; set; } = string.Empty;
        public DateTime ErrorDate { get; set; }
    }
}
