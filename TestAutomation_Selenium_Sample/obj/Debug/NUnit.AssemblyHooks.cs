// <auto-generated />
#pragma warning disable

using System.CodeDom.Compiler;
using System.Diagnostics;
using global::NUnit.Framework;
using global::TechTalk.SpecFlow;
using global::System.Runtime.CompilerServices;

[GeneratedCode("SpecFlow", "3.5.14")]
[SetUpFixture]
public class TestAutomation_Selenium_Sample_NUnitAssemblyHooks
{
    [OneTimeSetUp]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void AssemblyInitialize()
    {
        var currentAssembly = typeof(TestAutomation_Selenium_Sample_NUnitAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunStart(currentAssembly);
    }

    [OneTimeTearDown]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void AssemblyCleanup()
    {
        var currentAssembly = typeof(TestAutomation_Selenium_Sample_NUnitAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunEnd(currentAssembly);
    }
}
#pragma warning restore
