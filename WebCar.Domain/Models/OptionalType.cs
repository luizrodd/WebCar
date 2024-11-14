namespace WebCar.Domain.Models
{
    public class OptionalType
    {
        public OptionalTypeEnum Id { get; set; }
        public string Name { get; set; }

        public OptionalType(OptionalTypeEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
    }

    public enum OptionalTypeEnum
    {
        AirConditioning = 1,
        PowerSteering = 2,
        PowerWindows = 3,
        PowerLocks = 4,
        Airbag = 5,
        AbsBrakes = 6,
        LeatherSeats = 7,
        ParkingSensors = 8,
        RearCamera = 9,
        Sunroof = 10,
        OnboardComputer = 11,
        StabilityControl = 12,
        TractionControl = 13,
        FogLights = 14,
        AlloyWheels = 15,
        CruiseControl = 16,
        RainSensor = 17,
        AlarmSystem = 18,
        MultimediaSystem = 19,
        MultifunctionSteeringWheel = 20,
        PowerMirrors = 21,
        KeylessEntry = 22,
        HillStartAssist = 23,
        IsofixAnchors = 24,
        XenonHeadlights = 25,
        HeatedSeats = 26,
        SpeedLimiter = 27
    }
}
