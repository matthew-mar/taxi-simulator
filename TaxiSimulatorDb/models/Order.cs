using TaxiSimulatorDb.Structures;

namespace TaxiSimulatorDb.Models {
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

        public DbVector? DeparturePoint { get; set; }
        
        public string? DeparturePointName { get; set; }

        public DbVector? DestinationPoint { get; set; }

        public string? DestinationPointName { get; set; }

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
