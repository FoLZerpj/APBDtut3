namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    protected override char ContainerType => 'G';
    
    public override void EmptyCargo()
    {
        this.Mass = (float)Math.Max(0.05 * this.MaximumPayload, this.Mass);
    }
}