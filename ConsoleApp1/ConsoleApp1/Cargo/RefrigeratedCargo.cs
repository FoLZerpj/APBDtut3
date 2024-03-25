namespace ConsoleApp1.Cargo;

public interface RefrigeratedCargo : Cargo
{
    public float RequiredTemperature { get; protected set; }
}