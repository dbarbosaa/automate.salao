using AutomationTest.Core;

namespace Test.Cadastro
{
    public static class Cliente
    {
        public static void Clientes(SeleniumHelper selenium)
        {
            //Cadastro de Cliente;
            selenium.GoToUrl("http://localhost:5173/cliente/");
            selenium.Delay(30);
            selenium.ClickByXPath("/html/body/div/div/div[1]/div[5]/div/div[2]/div/div[2]/div/div[2]/button");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div/div[1]/div/input", "Celso Gabril");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div/div[2]/div/input", "teste@gmail.com");
            selenium.FillTextBoxByXPath("/html/body/div[3]/div/div/div[2]/form/div/div[3]/div/input", "81 96845-0150");
            selenium.Delay(30);
            selenium.ClickByXPath("/html/body/div[3]/div/div/div[3]/button[1]");
            selenium.Delay(30);

        }
    }
}
