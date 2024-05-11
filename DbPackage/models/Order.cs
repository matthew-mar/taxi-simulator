using DbPackage.Structures;

namespace DbPackage.Models {
    public class Order {
        public int Id { get; set; }

        public int? CompanyId { get; set; }

        public DbVector? DeparturePoint { get; set; }

        public string? DepartureName { get; set; }

        public string? DestinationName { get; set; }

        public DbVector? DestinationPoint { get; set; }

        public int? TarifPlanId { get; set; }

        public float? Price { get; set; }

        public long? CreatedAt { get; set; }

        public long? TakenAt { get; set; }

        public long? StartTime { get; set; }

        public long? EndTime { get; set; }

        public long? CompletedAt { get; set; }

        public int? Mark { get; set; }
    }
}
