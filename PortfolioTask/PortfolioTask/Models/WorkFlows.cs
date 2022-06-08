using System.Collections.Generic;

namespace PortfolioTask.Models
{
    public class WorkFlows
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skills> Skills { get; set; }

    }
}
