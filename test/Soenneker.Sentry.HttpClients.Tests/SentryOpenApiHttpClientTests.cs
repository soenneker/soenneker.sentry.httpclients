using Soenneker.Sentry.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Sentry.HttpClients.Tests;

[Collection("Collection")]
public sealed class SentryOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly ISentryOpenApiHttpClient _httpclient;

    public SentryOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<ISentryOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
