using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Pages
{
    public class PlanMyJourneyModel
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }

        public string TimeOptions { get; set; }

        public string Time { get; set; }

        public string Day { get; set; }

        public string Error { get; set; }
    }

    public class Errors
    {
        public IList<string> Error {  get; set; }
            
    }
}
