using AssettoServer.Server.Configuration;
using FluentValidation;

namespace SonmezDriftPlugin;

public class DriftConfiguration : IValidateConfiguration<DriftConfigurationValidator>
{
    // ---- Yarış ----
    public bool RaceEnabled { get; set; } = false;   // 3x korna ile yarış (iki pluginden sadece birinde açık olsun)
    public float RaceDistanceMeters { get; set; } = 1500f;
    public float RaceRadiusMeters { get; set; } = 20f;      // 3. kornada bu mesafedeki (metre) oyuncular yarışa alınır; 0 = sunucudaki herkes
    public int CountdownSeconds { get; set; } = 3;          // 3-2-1
    public int FinishBannerSeconds { get; set; } = 8;
    public int RaceTimeoutSeconds { get; set; } = 240;
    public int RaceWinBonus { get; set; } = 500;
    public int HornCount { get; set; } = 3;
    public int HornWindowMs { get; set; } = 3000;

    // ---- Puan ----
    public int MaxCombo { get; set; } = 3;
    public int ComboWindowMs { get; set; } = 4000;

    // ---- Makas ----
    public float MakasMinSpeedKmh { get; set; } = 80f;
    public float MakasCloseDistance { get; set; } = 3.5f;   // metre (araç merkezleri arası)
    public float MakasMinRelSpeedKmh { get; set; } = 15f;
    public int MakasPairCooldownMs { get; set; } = 2500;

    // ---- Drift ----
    public float DriftMinSpeedKmh { get; set; } = 40f;
    public float DriftMinAngle { get; set; } = 10f;
    public float DriftMaxAngle { get; set; } = 110f;
    public float DriftPointFactor { get; set; } = 0.02f;
}

public class DriftConfigurationValidator : AbstractValidator<DriftConfiguration>
{
    public DriftConfigurationValidator()
    {
        RuleFor(c => c.RaceDistanceMeters).GreaterThan(100f);
        RuleFor(c => c.CountdownSeconds).InclusiveBetween(1, 10);
        RuleFor(c => c.MaxCombo).GreaterThanOrEqualTo(1);
    }
}
