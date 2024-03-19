namespace ConsoleApp1;

public abstract class Container
{
    private float _mass;
    public float Mass
    {
        get => this._mass;
        private set
        {
            if (value > this.MaximumPayload)
            {
                throw new OverfillException();
            }

            this._mass = value;
        }
    }

    public float Height { get; private set; }
    public float TareWeight { get; private set; }
    public float Depth { get; private set; }
    public float MaximumPayload { get; private set; }

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

    private uint _serialNumber;
    public string SerialNumber => $"KON-{ContainerType}-{_serialNumber}";

    protected Container()
    {
        this._serialNumber = _NextSerialNumber;
    }

    public void EmptyCargo()
    {
        this.Mass = 0;
    }

    public void LoadAdditionalCargo(float weight)
    {
        this.Mass += weight;
    }
}