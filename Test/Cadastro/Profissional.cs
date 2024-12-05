using AutomationTest.Core;

namespace Test.Cadastro
{
    public static class Profissional
    {
        public static void Profissionais (SeleniumHelper selenium)
        {
            //Cadastro de profissional;
            selenium.GoToUrl("http://localhost:5173/profissional/");
            selenium.Delay(30);
            selenium.ClickByXPath("/html/body/div/div/div[1]/div[5]/div/div[2]/div/div[2]/div/div[2]/button");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div/div[1]/div/input", "Thiago Henrique");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div/div[2]/div/input", "Barbeiro");
            selenium.Delay(30);
            selenium.ClickByXPath("/html/body/div[3]/div/div/div[3]/button[1]");
            selenium.Delay(30);
        }
    }
}
