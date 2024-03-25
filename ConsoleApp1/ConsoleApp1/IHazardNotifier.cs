namespace ConsoleApp1;

public interface IHazardNotifier
{
    public event EventHandler<HazardEvent> HazardEventOccured;
}

public readonly struct HazardEvent(string information, string containerSerialNumber)
{
    public string Information => information;
    public string ContainerSerialNumber => containerSerialNumber;
}