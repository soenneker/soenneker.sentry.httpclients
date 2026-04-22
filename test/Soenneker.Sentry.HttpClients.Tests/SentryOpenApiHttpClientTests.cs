using Soenneker.Sentry.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Sentry.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SentryOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ISentryOpenApiHttpClient _httpclient;

    public SentryOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ISentryOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
