using DriverHelper.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using B2BAutomationTesting;
using Serilog;

namespace B2BAutomationTesting.UIAutomation.Pages
{
    class MessageChatWindowPage
    {
        public readonly ParallelConfig _parallelConfig;

        public MessageChatWindowPage(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }
        private IWebElement messageInput => _parallelConfig.Driver.Find(By.Id("NewMessageInput"));
        private IWebElement sendMessageButton => _parallelConfig.Driver.Find(By.Id("sendMessageButton"));
        private IWebElement firstMessageBubble => _parallelConfig.Driver.Find(By.Id("MessageBubble0"));
        private IWebElement secondMessageBubble => _parallelConfig.Driver.Find(By.Id("MessageBubble1"));
        private IWebElement searchMessageInput => _parallelConfig.Driver.Find(By.Id("searchMessage"));
        private IWebElement goBackButton => _parallelConfig.Driver.Find(By.Id("goBackButton"));


        public void SendMessages(string firstMessage, string secondMessage)
        {
            messageInput.SendKeys(firstMessage);
            sendMessageButton.Click();
            Thread.Sleep(1000);
            messageInput.SendKeys(secondMessage);
            sendMessageButton.Click();
            Thread.Sleep(1000);

        }
        public bool VerifyMessageSent(string firstMessage, string secondMessage)
        {
            if(firstMessageBubble.Text == firstMessage && secondMessageBubble.Text == secondMessage)
            {
                return true;
            }
            Log.Error("Couldn't Verfiy Messages were Sent");
            return false;
        }

        public void EnterSearch()
        {
            Thread.Sleep(1000);
            searchMessageInput.SendKeys("Second Test Message");
        }
        public bool VerifySearch()
        {
            if(firstMessageBubble.Text.Contains("Second Test Message"))
            {
                goBackButton.Click();
                return true;
            }
            Log.Error("Couldn't Verfiy Search filtered Messages");
            return false;
        }
    }
}
