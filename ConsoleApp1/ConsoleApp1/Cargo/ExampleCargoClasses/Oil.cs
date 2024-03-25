namespace ConsoleApp1.Cargo;

public class Oil(float weight) : HazardousCargo
{
    public float Weight { get; set; } = weight;
}