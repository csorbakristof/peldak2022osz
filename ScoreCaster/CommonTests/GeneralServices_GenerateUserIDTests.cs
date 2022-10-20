using Core.Services;
using System;
using Xunit;

namespace CommonTests
{
    public class GeneralServices_GenerateUserIDTests
    {
        private DummyIdentityManager identityManager;
        private GeneralServices service;
        public GeneralServices_GenerateUserIDTests()
        {
            identityManager = new DummyIdentityManager();
            service = new GeneralServices(identityManager);
        }

        [Fact]
        public void GenerateDummyIdentity()
        {
            _ = service.GenerateUserID(string.Empty);
            Assert.True(identityManager.GenerateIdentityCalled);
        }

    }
}