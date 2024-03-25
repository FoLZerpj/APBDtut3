namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
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
}