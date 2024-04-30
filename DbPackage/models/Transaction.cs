namespace DbPackage.Models {
    public class Transaction {
        public int Id { get; set; }

        public int? TypeId { get; set; }

        public float? Amount { get; set; }

        public long? CreatedAt { get; set; }
    }
}
