namespace ConsoleApp1;

public abstract class Container(float height, float tareWeight, float depth, float maximumPayload)
{
    private float _mass;
    public virtual float Mass
    {
        get => this._mass;
        protected set
        {
            if (value > this.MaximumPayload)
            {
                throw new OverfillException();
            }

            this._mass = value;
        }
    }

    public float Height => height;
    public float TareWeight => tareWeight;
    public float Depth => depth;
    public float MaximumPayload => maximumPayload;

    protected abstract char ContainerType { get; }

    private static uint _nextSerialNumber = 0;
    private static uint _NextSerialNumber
    {
        get
        {
            _nextSerialNumber += 1;
            return _nextSerialNumber;
        }
    }

    private readonly uint _serialNumber = _NextSerialNumber;
    public string SerialNumber => $"KON-{ContainerType}-{_serialNumber}";

    public virtual void EmptyCargo()
    {
        this.Mass = 0;
    }

    protected virtual void LoadAdditionalCargo(Cargo.Cargo cargo)
    {
        this.Mass += cargo.Weight;
    }

    public virtual void Print()
    {
        Console.Out.WriteLine($"   Height: {this.Height} cm, Tare Weight: {this.TareWeight} kg, Depth: {this.Depth} cm, Mass: {this.Mass} kg");
    }
}