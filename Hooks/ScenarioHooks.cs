using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTests.Models;

namespace UserTests.Hooks
{
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var env = TestContext.Parameters["environmentName"];

            Assert.IsTrue(!string.IsNullOrEmpty(env), "The environment variable is not set");
        }

        [AfterScenario]
        public void AfterScenario()
        {
          
        }
    }
}
