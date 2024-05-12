using System;

namespace TaxiSimulator.Common.Helpers {
    public class TimeTool {
        public static long NowTimestamp => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}
