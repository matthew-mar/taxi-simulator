namespace DbPackage.Models {
    public class Company {
        public int Id { get; set; }
        
        public string? Name { get; set; }
    
        public bool? PlayerSigned { get; set; }

        public string? IconPath { get; set; }
    }
}
