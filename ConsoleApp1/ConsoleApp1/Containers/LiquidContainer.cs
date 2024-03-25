using ConsoleApp1.Cargo;

namespace ConsoleApp1;

public class LiquidContainer(float height, float tareWeight, float depth, float maximumPayload) : Container(height, tareWeight, depth, maximumPayload), IHazardNotifier
{
    public event EventHandler<HazardEvent> HazardEventOccured;
    protected override char ContainerType => 'L';

    private bool _isHazardous = false;

    public override float Mass
    {
        get => base.Mass;
        protected set
        {
            float maxCap = _isHazardous ? 0.5f : 0.9f;
            if (base.Mass + value > maxCap * this.MaximumPayload)
            {
                this.HazardEventOccured?.Invoke(this, new HazardEvent("Attempt to add cargo over the maximum capacity", this.SerialNumber));
                throw new DangerousOperationException();
            }

            base.Mass += value;
        }
    }

    public void Load(HazardousCargo cargo)
    {
        this._isHazardous = true;
        this.LoadAdditionalCargo(cargo);
    }
    
    public void Load(Cargo.Cargo cargo)
    {
        this.LoadAdditionalCargo(cargo);
    }
    
    public override void Print()
    {
        Console.Out.WriteLine($"Liquid Container {this.SerialNumber}:");
        base.Print();
        Console.Out.WriteLine($"   Is Cargo Hazardous: {this._isHazardous}");
    }
}