namespace TaxiSumulatorDb.Models {
    public enum Plan {
        Economy,
        Comfort,
        Вusiness,
        Premium
    }

    public enum Status {
        Created,
        Taken,  // Ждет водителя
        InProgress,
        Completed,
    }

    public class Order {
        public int Id { get; set; }
        
        public string? DeparturePoint { get; set; }

        public string? DestinationPoint { get; set; }

        public int? Distance { get; set; }

        public Plan? Plan{ get; set; }

        public float? Price { get; set; }

        public Int64? StartTime { get; set; }

        public Int64? EndTime { get; set; }

        public Status? Status { get; set; }

        public Int64? CreatedAt { get; set; }

        public Int64? WaitingStartedAt { get; set; }

        public Int64? DriveStartedAt { get; set; }

        public Int64? CompletedAt { get; set; }
    }
}
