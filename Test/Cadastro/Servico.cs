using AutomationTest.Core;

namespace Test.Cadastro
{
    public static class Servico
    {
        public static void servicos(SeleniumHelper selenium)
        {
            //Cadastro de serviço;
            selenium.GoToUrl("http://localhost:5173/servicos/");
            selenium.Delay(30);
            selenium.ClickByXPath("/html/body/div/div/div[1]/div[5]/div/div[2]/div/div[2]/div/div[2]/button");
            selenium.Delay(20);
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div[1]/div[1]/div/input", "Unha");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div[1]/div[2]/div/input", "100");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div[2]/div/div/textarea", "Teste");
            selenium.Delay(20);
            selenium.ClickByXPath("/html/body/div[3]/div/div/div[3]/button[2]");
            selenium.Delay(30);
        }
    }
}
