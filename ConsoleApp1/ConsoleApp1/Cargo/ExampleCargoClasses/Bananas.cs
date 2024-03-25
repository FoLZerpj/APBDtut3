namespace ConsoleApp1.Cargo;

public class Bananas(float weight) : RefrigeratedCargo
{
    public float Weight { get; set; } = weight;
    public float RequiredTemperature { get; set; } = 13.3f;
}