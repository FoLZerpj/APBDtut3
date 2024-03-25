namespace ConsoleApp1;

public class ContainerShip(float maximumSpeed, float maximumWeight, uint maximumContainersNumber)
{
    public List<Container> Containers = new List<Container>();
    public float MaximumSpeed = maximumSpeed;
    public float MaximumWeight = maximumWeight;
    public uint MaximumContainersNumber = maximumContainersNumber;
    private float _currentWeight = 0;

    public void LoadContainer(Container container)
    {
        if (this._currentWeight + container.Mass + container.TareWeight > this.MaximumWeight * 1000)
        {
            throw new OverfillException();
        }

        if (this.Containers.Count + 1 > this.MaximumContainersNumber)
        {
            throw new OverfillException();
        }

        this._currentWeight += container.Mass + container.TareWeight;
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

    public void UpdateWeights()
    {
        this._currentWeight = 0;
        foreach (Container container in this.Containers)
        {
            this._currentWeight += container.Mass + container.TareWeight;
        }
    }
    
    public Container ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = this.Containers.FindIndex(x => x.SerialNumber == serialNumber);
        if (index == -1)
        {
            throw new ContainerNotFoundException();
        }
        Container container = this.Containers[index];
        this._currentWeight -= container.Mass + container.TareWeight;
        if (this._currentWeight + newContainer.Mass + newContainer.TareWeight > this.MaximumWeight * 1000)
        {
            throw new OverfillException();
        }
        this.Containers[index] = newContainer;
        this._currentWeight += newContainer.Mass + newContainer.TareWeight;
        return container;
    }

    public void Print()
    {
        Console.Out.WriteLine($"Container ship:");
        Console.Out.WriteLine($"   Maximum Speed: {this.MaximumSpeed} knots, Maximum Weight: {this.MaximumWeight} tons, Maximum Number Of Containers: {this.MaximumContainersNumber}");
        Console.Out.WriteLine($"Ship's containers:");
        foreach (Container container in this.Containers)
        {
            container.Print();
        }
        
    }
}