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
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\A36372\\Desktop\\Print\\";

            var teste = new Print();

            teste.GenerateSnapshot(filePath);        
            
            

            using (var engine = new TesseractEngine("C:\\Program Files (x86)\\Tesseract-OCR\\tessdata", "por", EngineMode.Default))
            {         

                Page ocrPage = engine.Process(Pix.LoadFromFile(filePath + "CaptchImage.png"), PageSegMode.AutoOnly);
                var captchatext = ocrPage.GetText().Trim();
                Console.WriteLine(captchatext.Replace("\n", "\r\n"));

                
            }

            Console.ReadKey();



        }  



        
    }
}
