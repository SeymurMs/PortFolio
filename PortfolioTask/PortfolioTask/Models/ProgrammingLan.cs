using System.Collections.Generic;

namespace PortfolioTask.Models
{
    public class ProgrammingLan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        List<Skills> skills { get; set; }

    }
}
