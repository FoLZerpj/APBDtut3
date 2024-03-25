using ConsoleApp1;
using ConsoleApp1.Cargo;

public class Program
{
    public static void Main(String[] args)
    {
        //Create a container of a given type
        GasContainer gasContainer = new GasContainer(10f, 20f, 50f, 500f);
        LiquidContainer liquidContainer = new LiquidContainer(10f, 20f, 50f, 500f);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(10f, 20f, 50f, 500f, typeof(Bananas), 50f);

        //Load cargo into a given container
        gasContainer.Load(new Hydrogen(5.5f));
        liquidContainer.Load(new Oil(10.0f));
        refrigeratedContainer.Load(new Bananas(25f));

        //Load a container onto a ship
        ContainerShip ship = new ContainerShip(10f, 25f);
        ship.LoadContainer(gasContainer);

        //Load a list of containers onto a ship
        ship.LoadContainerList([liquidContainer, refrigeratedContainer]);

        //Remove a container from the ship
        ship.RemoveContainer("KON-G-1");

        //Unload a container
        

        //Replace a container on the ship with a given number with another container

        //The possibility of transferring a container between two ships

        //Print information about a given container

        //Print information about a given ship and its cargo
    }
}