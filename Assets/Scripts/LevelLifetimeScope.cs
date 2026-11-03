using VContainer;
using VContainer.Unity;

public class LevelLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<PlayerInputController>(Lifetime.Scoped).AsSelf().AsImplementedInterfaces();

        builder.RegisterComponentInHierarchy<PlayerMovement>();
    }
}
