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
        AirConditioning = 0,
        PowerSteering = 1,
        PowerWindows = 2,
        PowerLocks = 3,
        Airbag = 4,
        AbsBrakes = 5,
        LeatherSeats = 6,
        ParkingSensors = 7,
        RearCamera = 8,
        Sunroof = 9,
        OnboardComputer = 10,
        StabilityControl = 11,
        TractionControl = 12,
        FogLights = 13,
        AlloyWheels = 14,
        CruiseControl = 15,
        RainSensor = 16,
        AlarmSystem = 17,
        MultimediaSystem = 18,
        MultifunctionSteeringWheel = 19,
        PowerMirrors = 20,
        KeylessEntry = 21,
        HillStartAssist = 22,
        IsofixAnchors = 23,
        XenonHeadlights = 24,
        HeatedSeats = 25,
        SpeedLimiter = 26
    }
}
