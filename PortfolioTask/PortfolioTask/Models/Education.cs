using System;

namespace PortfolioTask.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public double Raiting { get; set; }
    }
}
