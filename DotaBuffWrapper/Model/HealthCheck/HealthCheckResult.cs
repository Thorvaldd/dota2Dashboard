using DotaBuffWrapper.Model.HealthCheck.Interfaces;

namespace DotaBuffWrapper.Model.HealthCheck
{
    internal class HealthCheckResult : IHealthCheckResult
    {
        public bool IsYaspAvailable { get; internal set; }
        public bool IsDotabuffAvailable { get; internal set; }

        public bool AreAllSystemsLive { get { return IsYaspAvailable && IsDotabuffAvailable; } }

        internal HealthCheckResult()
        {

        }

        internal HealthCheckResult(bool isYaspAvailable, bool isDotabuffAvailabl)
        {
            IsYaspAvailable = isYaspAvailable;
            IsDotabuffAvailable = isDotabuffAvailabl;
        }
    }
}
