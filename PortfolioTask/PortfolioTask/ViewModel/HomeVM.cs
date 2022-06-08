using PortfolioTask.Models;
using System.Collections.Generic;

namespace PortfolioTask.ViewModel
{
    public class HomeVM
    {
        public List<About> abouts { get; set; }
        public List<Experience> experiences{ get; set; }
        public List<Education> educations { get; set; }
        public List<Skills> skills { get; set; }
    }
}
