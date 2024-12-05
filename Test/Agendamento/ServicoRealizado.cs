using AutomationTest.Core;


namespace Test.Agendamento
{
    public static class ServicoRealizado
    {
        public static void ServicosRealizados(SeleniumHelper selenium)
        {
            string dataAtual = DateTime.Now.ToString("dd-MM-yyyy");

            selenium.GoToUrl("http://localhost:5173/servicorealizado/");
            selenium.Delay(20);
            selenium.ClickByXPath("/html/body/div/div/div[1]/div[5]/div/div[2]/div/div[2]/div/div[2]/button");
            selenium.FillBySelectByXPath("/html/body/div[3]/div/div/div[2]/form/div[1]/div[1]/div/input", "1");
            selenium.FillBySelectByXPath("/html/body/div[3]/div/div/div[2]/form/div[1]/div[2]/div/input", "1");
            selenium.FillBySelectByXPath("/html/body/div[3]/div/div/div[2]/form/div[2]/div[1]/div/input", dataAtual);
            selenium.FillBySelectByXPath("/html/body/div[3]/div/div/div[2]/form/div[2]/div[2]/div/input", "100");
            selenium.Delay(20);
            selenium.ClickByXPath("/html/body/div[3]/div/div/div[3]/button[2]");
        }
    }
}
