namespace FeatureFlagsDemo.Core.Entities.Weather
{
    public class Current
    {
        public float temp_c { get; set; }
        public float wind_mph { get; set; }
        public float humidity { get; set; }

        public Condition Condition { get; set; } = new Condition();
    }
}
