using DriverHelper.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using B2BAutomationTesting.UIAutomation.Pages;
using B2BAutomationTesting;

namespace B2BAutomationTesting.UIAutomation.Steps
{
    [Binding]
    class MessageChatWindowSteps
    {
        private readonly MessageChatWindowPage _messageWindow;
        public readonly ParallelConfig _parallelConfig;

        public MessageChatWindowSteps(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _messageWindow = new MessageChatWindowPage(_parallelConfig);

        }

        [When(@"Check Sending Two Messages ""([^""]*)"" and ""([^""]*)""")]
        public bool WhenCheckSendingTwoMessagesAnd(string firstMessage, string secondMessage)
        {
            _messageWindow.SendMessages(firstMessage, secondMessage);
            if(_messageWindow.VerifyMessageSent(firstMessage, secondMessage))
            {
                return true;
            }
            return false;
        }

        [When(@"Verify Searching Messages")]
        public void WhenVerifySearchingMessages()
        {
            _messageWindow.EnterSearch();
            _messageWindow.VerifySearch();

        }



    }
}
