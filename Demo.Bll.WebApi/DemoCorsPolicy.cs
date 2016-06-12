using System;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class DemoCorsPolicyAttribute : Attribute, ICorsPolicyProvider
{
    private CorsPolicy _policy;

    public DemoCorsPolicyAttribute()
    {
        // Create a CORS policy.
        _policy = new CorsPolicy
        {
            AllowAnyMethod = true,
            AllowAnyHeader = true
        };

        // Add allowed origins.
        string[] origins = ConfigurationManager.AppSettings["Cors"].Split(',');
        foreach (string origin in origins)
        {
            _policy.Origins.Add(origin);
        }
    }

    public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_policy);
    }
}