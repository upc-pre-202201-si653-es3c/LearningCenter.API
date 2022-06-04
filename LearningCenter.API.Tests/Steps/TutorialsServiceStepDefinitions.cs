using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LearningCenter.API.Tests.Steps;

[Binding]
public sealed class TutorialsServiceStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    public TutorialsServiceStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        _scenarioContext.Pending();
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        //TODO: implement arrange (precondition) logic
        // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
        // To use the multiline text or the table argument of the scenario,
        // additional string/Table parameters can be defined on the step definition
        // method. 

        _scenarioContext.Pending();
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        //TODO: implement act (action) logic

        _scenarioContext.Pending();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        //TODO: implement assert (verification) logic

        _scenarioContext.Pending();
    }

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/tutorials is available")]
    public void GivenTheEndpointHttpsLocalhostApiVTutorialsIsAvailable(int port, int version)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveTutorialResource)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"A Response with Status (.*) is received")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        ScenarioContext.StepIsPending();
    }
}