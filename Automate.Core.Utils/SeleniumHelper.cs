using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Chrome;

namespace AutomationTest.Core
{
    public class SeleniumHelper : IDisposable
    {
        IWebDriver WebDriver = new ChromeDriver();
        public readonly ConfigurationHelper Configuration;
        public WebDriverWait Wait;
        public SeleniumHelper(ConfigurationHelper configuration)
        {
            Configuration = configuration;
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(configuration.LoadPageTimeout));
        }
        public string GetUrl()
        {
            return WebDriver.Url;
        }
        public void GoToUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
        public bool VaidateContentUrl(string content)
        {
            return Wait.Until(ExpectedConditions.UrlContains(content));
        }
        public void ClickByTextLink(string textLink)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(textLink)));
            link.Click();
        }
        public void ClickByButtomId(string buttomId)
        {
            var buttom = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(buttomId)));
            Wait.Until(ExpectedConditions.ElementToBeClickable(buttom)).Click();
        }
        public void FillById(string xPath, string value)
        {
            // Aguarde até que os elementos sejam visíveis e, em seguida, pegue todos eles
            var elements = Wait.Until(driver => driver.FindElements(By.TagName(xPath)));

            // Verifique se existem elementos suficientes antes de acessar a posição 6
            if (elements.Count > 6)
            {
                var element = elements[11];
                element.Click();
                element.SendKeys(value);
                element.SendKeys(Keys.Enter);
            }
            else
            {
                throw new Exception("Não há elementos suficientes na lista para acessar a posição 6.");
            }
        }

        public void FillBySelectByXPath(string xPath, string value)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            element.Click();

            element.SendKeys(value);
            element.SendKeys(Keys.Enter);
        }

        public void ClickByButtomCssSelector(string cssSelector)
        {
            var buttom = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
            Wait.Until(ExpectedConditions.ElementToBeClickable(buttom)).Click();
        }
        public void ClickByXPath(string xPath)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            element.Click();
        }
        public void Delay(int delay)
        {
            Thread.Sleep(delay * 100);
        }
        public void ClickById(string id)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
            element.Click();
        }
        public IWebElement GetElementById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        }
        public IWebElement GetElementByClass(string classeCss)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classeCss)));
        }
        public IWebElement GetElementByXPath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }
        public string GetTextByXPath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath))).Text;
        }
        public void FillTextBoxById(string fieldId, string value)
        {
            var field = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(fieldId)));
            field.SendKeys(value);
        }
        public void FillTextBoxByXPath(string fieldId, string value)
        {
            var field = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(fieldId)));
            field.SendKeys(value);
        }
        public void FillDropDownById(string fieldId, string value)
        {
            var field = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(fieldId)));
            var selectElement = new SelectElement(field);
            selectElement.SelectByValue(value);
        }
        public string GetTextElementByClasseCss(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }
        public void MouseOverByXPath(string xpath)
        {
            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            Actions action = new Actions(WebDriver);
            action.MoveToElement(element).Perform();
        }
        public void MoveScrollByXPath(string xpath)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            IWebElement element = Wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath))).FindElement(By.XPath(xpath));
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
        public string GetTextElementById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }
        public string GetTextBoxValueById(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)))
                .GetAttribute("value");
        }
        public IEnumerable<IWebElement> GetListByClass(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }
        public bool ElementByIdIsVisible(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Displayed;
        }
        public bool ElementByIdIsInvisible(string id)
        {
            return Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(id)));
        }
        public bool ExistsElementById(string id)
        {
            return ElementExists(By.Id(id));
        }
        public bool ExistsElementByClassName(string className)
        {
            return ElementExists(By.ClassName(className));
        }
        public bool ExistsElementByCssSelector(string cssSelector)
        {
            return ElementExists(By.CssSelector(cssSelector));
        }
        public bool RadioButtomIsSelected(string id)
        {
            var value = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).GetAttribute("checked");
            return value == "true";
        }
        public void BackNavigation(int vezes = 1)
        {
            for (var i = 0; i < vezes; i++)
            {
                WebDriver.Navigate().Back();
            }
        }


        public bool ElementExistsNoWaiting(By by)
        {
            try
            {
                var a = WebDriver.FindElement(by);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private bool ElementExists(By by)
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementExists(by)).FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void Dispose()
        {
            if (WebDriver != null)
            {
                WebDriver.Dispose();
                WebDriver = null;
            }
        }
        public void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }
        public void TakeScreenshot(string directory, string fileName)
        {
            // Verifica se o diretório existe, se não, cria-o
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Captura a screenshot
            ITakesScreenshot screenshotDriver = WebDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();


            // Salva a screenshot no diretório especificado com o nome de arquivo fornecido
            string filePath = Path.Combine(directory, fileName);
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
        }

        public void ClearAndFillField(string xPath, string text)
        {

            var element = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            element.Clear(); // Limpa o conteúdo do campo
            element.SendKeys(text); // inserir novo texto
        }

        // ... código existente ...
    }
}