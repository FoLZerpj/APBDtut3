namespace ConsoleApp1;

public class GasContainer(float height, float tareWeight, float depth, float maximumPayload) : Container(height, tareWeight, depth, maximumPayload), IHazardNotifier
{
    public event EventHandler<HazardEvent> HazardEventOccured;
    
    public float Pressure { get; set; }
    
    protected override char ContainerType => 'G';
    
    public void Load(Cargo.Cargo cargo)
    {
        this.LoadAdditionalCargo(cargo);
    }

    public override void EmptyCargo()
    {
        this.Mass = (float)Math.Max(0.05 * this.MaximumPayload, this.Mass);
    }

    public override void Print()
    {
        Console.Out.WriteLine($"Gas Container {this.SerialNumber}:");
        base.Print();
        Console.Out.WriteLine($"   Pressure: {this.Pressure} atm");
    }
}