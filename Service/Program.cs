

namespace AWDataService
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Microsoft.ServiceBus;
    using System.ServiceModel.Web;

    class Program
    {
        static void Main(string[] args)
        {
            // Before running replace the servicebus namespace (next line) and REPLACESERVICEBUSKEY (app.config)
            string serviceNamespace = "jaimeta";
            Console.Write("Your Service Namespace: ");
            
            
            // Tranport level security is required for all *RelayBindings; hence, using https is required
            Uri address = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, "DemoJaimeDataService");

            WebServiceHost host = new WebServiceHost(typeof(DemoService), address);
            host.Open();

            Console.WriteLine(address + "Product/318");
            Console.WriteLine();
            Console.WriteLine(address + "GetImage");
            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();

            host.Close();
        }
    }
}