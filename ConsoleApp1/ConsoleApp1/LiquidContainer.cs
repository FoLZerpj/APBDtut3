namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    protected override char ContainerType => 'L';

    private bool isHazardous = false;

    public override float Mass
    {
        get => base.Mass;
        protected set
        {
            float maxCap = isHazardous ? 0.5f : 0.9f;
            if (base.Mass + value > maxCap * this.MaximumPayload)
            {
                throw new DangerousOperationException();
            }

            base.Mass += value;
        }
    }

    public override void LoadAdditionalCargo(Cargo.Cargo cargo)
    {
        base.LoadAdditionalCargo(cargo);
        if (cargo.IsHazardous)
        {
            this.isHazardous = true;
        }
    }
}