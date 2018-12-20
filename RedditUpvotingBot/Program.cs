using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace RedditUpvoteScript
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://old.reddit.com/");
            //prompt user for login details
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();
            //string userName = "Test";
            Console.WriteLine("Please enter your password");
            string passWord = Console.ReadLine();
            //string passWord = "Test";

            //username
            IWebElement userNamField = driver.FindElement(By.CssSelector("#login_login-main > input[type=\"text\"]:nth-child(2)"));

            userNamField.SendKeys(userName);
            //password
            IWebElement passwordField = driver.FindElement(By.CssSelector("#login_login-main > input[type=\"password\"]:nth-child(3)"));
            passwordField.SendKeys(passWord);
            //click login
            IWebElement loginBtn = driver.FindElement(By.CssSelector("#login_login-main > div.submit > button"));
            loginBtn.Click();
            driver.Navigate().GoToUrl("https://old.reddit.com/r/FreeKarma4U/");

            //List all posts on page by name
            //enter each post and upvote/comment on everything
            //if cant find pot/if its moved off front give error and move onto next postname in list

            //# thing_t3_a7ltch
            //# thing_t3_a7hoya
            //look for element containng thing_t3
            Console.WriteLine("blah");
            driver.Quit();


            //more comments for git commit here
        }

    }
}
