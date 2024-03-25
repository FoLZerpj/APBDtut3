using ConsoleApp1.Cargo;

namespace ConsoleApp1;

public class RefrigeratedContainer(float height, float tareWeight, float depth, float maximumPayload, Type typeOfStoredProduct, float temperature) : Container(height, tareWeight, depth, maximumPayload)
{
    protected override char ContainerType => 'C';
    public Type TypeOfStoredProduct => typeOfStoredProduct;
    public float Temperature => temperature;

    public void Load(RefrigeratedCargo cargo)
    {
        if (this.TypeOfStoredProduct != cargo.GetType())
        {
            throw new CargoTypeCannotBeStoredException();
        }

        //This doesn't make any sense but task requires it like this
        if (this.Temperature < cargo.RequiredTemperature)
        {
            throw new TemperatureTooLowException(); 
        }
        
        this.LoadAdditionalCargo(cargo);
    }
}