using VContainer;
using VContainer.Unity;

public class LevelLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerInputController>(Lifetime.Scoped).AsSelf();

        builder.RegisterComponentInHierarchy<PlayerController>();
    }
}
