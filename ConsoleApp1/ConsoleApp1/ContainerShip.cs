namespace ConsoleApp1;

public class ContainerShip(float maximumSpeed, float maximumWeight)
{
    public List<Container> Containers = new List<Container>();
    public float MaximumSpeed = maximumSpeed;
    public float MaximumWeight = maximumWeight;
    private float _currentWeight = 0;

    public void LoadContainer(Container container)
    {
        if (this._currentWeight + container.Mass > this.MaximumWeight * 1000)
        {
            throw new OverfillException();
        }

        this._currentWeight += container.Mass;
        this.Containers.Add(container);
    }

    public void LoadContainerList(Container[] containers)
    {
        foreach (Container container in containers)
        {
            this.LoadContainer(container);
        }
    }

    public Container RemoveContainer(string serialNumber)
    {
        int index = this.Containers.FindIndex(x => x.SerialNumber == serialNumber);
        if (index == -1)
        {
            throw new ContainerNotFoundException();
        }
        Container container = this.Containers[index];
        this.Containers.RemoveAt(index);
        return container;
    }
    
    
}