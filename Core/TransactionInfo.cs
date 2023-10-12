namespace CoreAdditional
{
    public class TransactionInfo
    {
       
            public Guid IdTransaction { get; set; }
            public double Amount { get; set; }
            public DateTime CreateTime { get; set; }
            public string Status { get; set; }
            public int UserId { get; set; }
            

    }
}
