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
        ContainerShip ship = new ContainerShip(10f, 25f, 5);
        ship.LoadContainer(gasContainer);

        //Load a list of containers onto a ship
        ship.LoadContainerList([liquidContainer, refrigeratedContainer]);

        //Remove a container from the ship
        ship.RemoveContainer("KON-G-1");

        //Unload a container
        gasContainer.EmptyCargo();
        ship.UpdateWeights();

        //Replace a container on the ship with a given number with another container
        GasContainer newGasContainer = new GasContainer(10f, 20f, 50f, 500f);
        ship.ReplaceContainer("KON-L-2", newGasContainer);

        //The possibility of transferring a container between two ships
        ContainerShip ship2 = new ContainerShip(10f, 25f, 5);
        Container container = ship.RemoveContainer("KON-C-3");
        ship2.LoadContainer(container);

        //Print information about a given container
        refrigeratedContainer.Print();

        //Print information about a given ship and its cargo
        ship2.Print();
    }
}