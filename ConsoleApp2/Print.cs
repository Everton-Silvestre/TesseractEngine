using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System.IO;
using Tesseract;

namespace ConsoleApp2
{
    public class Print
    {
        public void GenerateSnapshot(string filePath)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); driver.Navigate().GoToUrl("http://gps.receita.fazenda.gov.br/");

            var remElement = driver.FindElement(By.Id("captcha_challenge"));
            Point location = remElement.Location;

            var screenshot = (driver as ChromeDriver).GetScreenshot();
            using (MemoryStream stream = new MemoryStream(screenshot.AsByteArray))
            {
                using (Bitmap bitmap = new Bitmap(stream))
                {
                    RectangleF part = new RectangleF(location.X, location.Y, remElement.Size.Width, remElement.Size.Height);
                    using (Bitmap bn = bitmap.Clone(part, bitmap.PixelFormat))
                    {
                        bn.Save(filePath + "CaptchImage.png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }
    }
}
