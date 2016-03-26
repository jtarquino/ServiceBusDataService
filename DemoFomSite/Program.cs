using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DemoFomSite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Before running replace the servicebus namespace (next line) and REPLACESERVICEBUSKEY (app.config)
            string serviceNamespace = "jtarquino";
            string serviceBusKey = "REPLACEKEYHERE";
            Console.Write("Your Service Namespace: ");


            // Tranport level security is required for all *RelayBindings; hence, using https is required
            Uri address = ServiceBusEnvironment.CreateServiceUri("https", serviceNamespace, "Timer");

            WebServiceHost host = new WebServiceHost(typeof(ProblemSolver), address);


            WebHttpRelayBinding binding = new WebHttpRelayBinding(EndToEndWebHttpSecurityMode.None, RelayClientAuthenticationType.None);

            host.AddServiceEndpoint(
               typeof(IProblemSolver), binding, address)
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", serviceBusKey)
                });

            host.Open();
            Console.WriteLine(address + "CurrentTime");
            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            host.Close();
        }
    }
}


