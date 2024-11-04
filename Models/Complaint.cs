public class Complaint
{
    public int ComplaintId { get; set; }
    public string CustomerName { get; set; }
    public string Description { get; set; }
    public DateTime DateSubmitted { get; set; }
    public bool IsResolved { get; set; }
}
