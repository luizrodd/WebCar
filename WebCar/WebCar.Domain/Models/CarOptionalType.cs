namespace WebCar.Domain.Models
{
    public class CarOptionalType
    {
        public CarOptionalTypeEnum Id { get; private set; }
        public string Name { get; private set; }

        public CarOptionalType(CarOptionalTypeEnum id)
        {
            Id = id;
            Name = id.ToString();
        }
    }

    public enum CarOptionalTypeEnum
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
