// <copyright file="AccreditiTest.cs">Copyright ©  2016</copyright>
using System;
using EnerBank.Model;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnerBank.Model.Tests
{
    /// <summary>This class contains parameterized unit tests for Accrediti</summary>
    [PexClass(typeof(Accrediti))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AccreditiTest
    {
    }
}
