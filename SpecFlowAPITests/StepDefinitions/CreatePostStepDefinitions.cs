using NUnit.Framework;
using RestAPIAutomationBL.Utils;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowAPITests.StepDefinitions
{
    [Binding]
    public class CreatePostStepDefinitions
    {
        [Given(@"I create a new post using id '([^']*)' title '([^']*)' and author '([^']*)'")]
        public void GivenICreateANewPostUsingIdTitleAndAuthor(int id, string title, string author)
        {            
           var response = PostUtils.CreatePost(id, title, author);
            Assert.AreEqual(id, response.id);
            Assert.AreEqual(title, response.title);
            Assert.AreEqual(author, response.author);
           
        }

        [Given(@"I deleted the created with id '([^']*)' title '([^']*)' and author '([^']*)'")]
        public void GivenIDeletedTheCreatedWithIdTitleAndAuthor(int id, string title, string author)
        {
            var response = PostUtils.DeletePost(id);

        }
    }
}
