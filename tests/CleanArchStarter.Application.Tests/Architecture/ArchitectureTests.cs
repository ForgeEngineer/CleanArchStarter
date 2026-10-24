namespace CleanArchStarter.Application.Tests.Architecture;

using CleanArchStarter.Application.Common.Interfaces;
using CleanArchStarter.Domain.Common;
using NetArchTest.Rules;

public class ArchitectureTests
{
    private const string ApplicationNamespace = "CleanArchStarter.Application";
    private const string InfrastructureNamespace = "CleanArchStarter.Infrastructure";
    private const string ApiNamespace = "CleanArchStarter.API";

    [Fact]
    public void Domain_Should_Not_DependOnAnyOtherProject()
    {
        var result = Types.InAssembly(typeof(BaseEntity).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(ApplicationNamespace, InfrastructureNamespace, ApiNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful, BuildMessage(result));
    }

    [Fact]
    public void Application_Should_Not_DependOnInfrastructureOrApi()
    {
        var result = Types.InAssembly(typeof(IProductRepository).Assembly)
            .ShouldNot()
            .HaveDependencyOnAny(InfrastructureNamespace, ApiNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful, BuildMessage(result));
    }

    private static string BuildMessage(TestResult result)
        => result.FailingTypes is { Count: > 0 }
            ? string.Join(", ", result.FailingTypes.Select(t => t.FullName))
            : string.Empty;
}
