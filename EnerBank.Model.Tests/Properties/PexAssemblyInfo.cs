// <copyright file="PexAssemblyInfo.cs">Copyright ©  2016</copyright>
using Microsoft.Pex.Framework.Coverage;
using Microsoft.Pex.Framework.Creatable;
using Microsoft.Pex.Framework.Instrumentation;
using Microsoft.Pex.Framework.Settings;
using Microsoft.Pex.Framework.Validation;

// Microsoft.Pex.Framework.Settings
[assembly: PexAssemblySettings(TestFramework = "VisualStudioUnitTest")]

// Microsoft.Pex.Framework.Instrumentation
[assembly: PexAssemblyUnderTest("EnerBank.Model")]
[assembly: PexInstrumentAssembly("System.Core")]
[assembly: PexInstrumentAssembly("EnerBank.DataItem")]
[assembly: PexInstrumentAssembly("EnerBank.Interfaces")]
[assembly: PexInstrumentAssembly("EnerBank.IOUtils")]

// Microsoft.Pex.Framework.Creatable
[assembly: PexCreatableFactoryForDelegates]

// Microsoft.Pex.Framework.Validation
[assembly: PexAllowedContractRequiresFailureAtTypeUnderTestSurface]
[assembly: PexAllowedXmlDocumentedException]

// Microsoft.Pex.Framework.Coverage
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "System.Core")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EnerBank.DataItem")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EnerBank.Interfaces")]
[assembly: PexCoverageFilterAssembly(PexCoverageDomain.UserOrTestCode, "EnerBank.IOUtils")]

