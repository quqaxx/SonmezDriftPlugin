using Autofac;
using AssettoServer.Server.Plugin;
using Microsoft.Extensions.Hosting;

namespace SonmezDriftPlugin;

public class DriftModule : AssettoServerModule<DriftConfiguration>
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DriftService>().AsSelf().As<IHostedService>().SingleInstance();
    }
}
