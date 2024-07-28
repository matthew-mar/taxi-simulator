namespace DbPackage.Models {
    public class TarifPlanName {
        private static Dictionary<TarifPlans, string> _plans = new() {
            { TarifPlans.Economy, "Эконом" },
            { TarifPlans.Comfort, "Комфорт"},
            { TarifPlans.Business, "Бизнес" },
            { TarifPlans.Premium, "Премиум" },
        };

        public static string TarifPlan(int tarifPlanId) => _plans[(TarifPlans)tarifPlanId];
    }

    public enum TarifPlans {
        Economy = 1,
        Comfort = 2,
        Business = 3,
        Premium = 4,
    }

    public class TarifPlan {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
