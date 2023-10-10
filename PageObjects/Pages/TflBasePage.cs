using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public abstract class TflBasePage
    {
        public TflBasePage (IWebDriver webDriver)
        {
            WebDriver = webDriver;

        }
        protected IWebDriver WebDriver { get; } 
    }
}
