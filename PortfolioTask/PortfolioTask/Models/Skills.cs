namespace PortfolioTask.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProgrammingLanId { get; set; }
        public ProgrammingLan ProgLan { get; set; }
        public int WorkFlowsId { get; set; }
        public WorkFlows WorkFlows { get; set; }
    }
}
