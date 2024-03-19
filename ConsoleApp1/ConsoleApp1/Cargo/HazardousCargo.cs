namespace ConsoleApp1.Cargo;

public interface HazardousCargo : Cargo
{
    bool Cargo.IsHazardous => true;
}