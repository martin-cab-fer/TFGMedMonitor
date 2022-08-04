using System;
using System.Collections.Generic;

namespace Model.HealthService
{
    public class AnalyticBlock
    {
        public List<Analytic> Analytics { get; private set; }

        public bool ExistsMoreAnalytics { get; private set; }

        public AnalyticBlock(List<Analytic> analytics, bool existsMoreAnalytics)
        {
            Analytics = analytics;
            ExistsMoreAnalytics = existsMoreAnalytics;
        }

    }
}
