using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLFramework.Drivers;

namespace TFLFramework.AppConfig
{
    public class AppSettings
    {
        public string? Url { get; set; }
        public BrowserTypes BrowserType { get; set; }
    }
}
