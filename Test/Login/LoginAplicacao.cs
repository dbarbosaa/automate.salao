using AutomationTest.Core;

namespace Test.Login
{
    public static class LoginAplicacao
    { 
        public static void Logar ( SeleniumHelper selenium) {
            selenium.GoToUrl("http://localhost:5173");
            selenium.MaximizeWindow();
            selenium.FillTextBoxByXPath("/html/body/div/div/div/div[2]/div/div/div/div/div/div/div[2]/div/form/div[1]/input", "dani@salao.com");
            selenium.FillTextBoxByXPath("/html/body/div/div/div/div[2]/div/div/div/div/div/div/div[2]/div/form/div[2]/input", "123");
            selenium.ClickByXPath("/html/body/div/div/div/div[2]/div/div/div/div/div/div/div[2]/div/form/button");
            selenium.Delay(30);
        }
    }
}
