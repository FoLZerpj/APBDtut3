using ConsoleApp1.Cargo;

namespace ConsoleApp1;

public class RefrigeratedContainer : Container
{
    protected override char ContainerType => 'C';
    public Type TypeOfStoredProduct { get; private set; }
    public float Temperature { get; private set; }

    public RefrigeratedContainer(Type typeOfStoredProduct)
    {
        this.TypeOfStoredProduct = typeOfStoredProduct;
    }

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