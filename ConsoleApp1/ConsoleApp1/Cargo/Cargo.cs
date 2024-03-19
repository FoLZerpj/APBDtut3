namespace ConsoleApp1.Cargo;

public interface Cargo
{
    public bool IsHazardous => false;
    
    public float Weight { get; protected set; }
}