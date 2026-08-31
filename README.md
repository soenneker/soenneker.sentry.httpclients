[![](https://img.shields.io/nuget/v/soenneker.sentry.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sentry.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sentry.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sentry.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sentry.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sentry.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sentry.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.sentry.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Sentry.HttpClients

Provides a cached `HttpClient` for Sentry organizations, projects, teams, issues, events, releases, alerts, integrations, and account resources.

## Installation

```bash
dotnet add package Soenneker.Sentry.HttpClients
```

## Configuration

```json
{
  "Sentry": {
    "ApiKey": "your-sentry-auth-token"
  }
}
```

## Usage

```csharp
using Soenneker.Sentry.HttpClients.Abstract;
using Soenneker.Sentry.HttpClients.Registrars;

services.AddSentryOpenApiHttpClientAsSingleton();

public sealed class SentryOrganizationReader
{
    private readonly ISentryOpenApiHttpClient _sentry;

    public SentryOrganizationReader(ISentryOpenApiHttpClient sentry)
    {
        _sentry = sentry;
    }

    public async Task<string> GetOrganizations(CancellationToken cancellationToken)
    {
        HttpClient client = await _sentry.Get(cancellationToken);
        return await client.GetStringAsync("api/0/organizations/", cancellationToken);
    }
}
```

The provider sends `Authorization: Bearer <token>` and targets `https://sentry.io/`. For self-hosted Sentry, set `Sentry:ClientBaseUrl` to the installation origin, without appending `/api/0`. Header name and value formatting can be overridden with `Sentry:AuthHeaderName` and `Sentry:AuthHeaderValueTemplate`.
