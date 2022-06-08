using System;

namespace PortfolioTask.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string  Description { get; set; }
    }
}
