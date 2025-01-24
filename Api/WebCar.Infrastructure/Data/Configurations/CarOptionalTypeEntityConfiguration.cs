using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCar.Domain.Models;

namespace WebCar.Infrastructure.Data.Configurations;

public class CarOptionalTypeEntityConfiguration : IEntityTypeConfiguration<CarOptionalType>
{
    public void Configure(EntityTypeBuilder<CarOptionalType> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasConversion<int>()
               .ValueGeneratedNever();

        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasData(
            new { Id = CarOptionalTypeEnum.AirConditioning, Name = "Air Conditioning" },
            new { Id = CarOptionalTypeEnum.PowerSteering, Name = "Power Steering" },
            new { Id = CarOptionalTypeEnum.PowerWindows, Name = "Power Windows" },
            new { Id = CarOptionalTypeEnum.PowerLocks, Name = "Power Locks" },
            new { Id = CarOptionalTypeEnum.Airbag, Name = "Airbag" },
            new { Id = CarOptionalTypeEnum.AbsBrakes, Name = "ABS Brakes" },
            new { Id = CarOptionalTypeEnum.LeatherSeats, Name = "Leather Seats" },
            new { Id = CarOptionalTypeEnum.ParkingSensors, Name = "Parking Sensors" },
            new { Id = CarOptionalTypeEnum.RearCamera, Name = "Rear Camera" },
            new { Id = CarOptionalTypeEnum.Sunroof, Name = "Sunroof" },
            new { Id = CarOptionalTypeEnum.OnboardComputer, Name = "Onboard Computer" },
            new { Id = CarOptionalTypeEnum.StabilityControl, Name = "Stability Control" },
            new { Id = CarOptionalTypeEnum.TractionControl, Name = "Traction Control" },
            new { Id = CarOptionalTypeEnum.FogLights, Name = "Fog Lights" },
            new { Id = CarOptionalTypeEnum.AlloyWheels, Name = "Alloy Wheels" },
            new { Id = CarOptionalTypeEnum.CruiseControl, Name = "Cruise Control" },
            new { Id = CarOptionalTypeEnum.RainSensor, Name = "Rain Sensor" },
            new { Id = CarOptionalTypeEnum.AlarmSystem, Name = "Alarm System" },
            new { Id = CarOptionalTypeEnum.MultimediaSystem, Name = "Multimedia System" },
            new { Id = CarOptionalTypeEnum.MultifunctionSteeringWheel, Name = "Multifunction Steering Wheel" },
            new { Id = CarOptionalTypeEnum.PowerMirrors, Name = "Power Mirrors" },
            new { Id = CarOptionalTypeEnum.KeylessEntry, Name = "Keyless Entry" },
            new { Id = CarOptionalTypeEnum.HillStartAssist, Name = "Hill Start Assist" },
            new { Id = CarOptionalTypeEnum.IsofixAnchors, Name = "Isofix Anchors" },
            new { Id = CarOptionalTypeEnum.XenonHeadlights, Name = "Xenon Headlights" },
            new { Id = CarOptionalTypeEnum.HeatedSeats, Name = "Heated Seats" },
            new { Id = CarOptionalTypeEnum.SpeedLimiter, Name = "Speed Limiter" }
            );


    }
}
