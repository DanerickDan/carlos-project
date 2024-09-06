using BusinessLayer.Model;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using PresentationLayer.AddForms;
using PresentationLayer.UpdateForms;

namespace PresentationLayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ProductsDTO test = new();
            Application.Run(new MainForm());
        }
        
    }
}