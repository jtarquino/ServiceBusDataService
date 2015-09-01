

namespace AWDataService
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    using System.IO;

    [ServiceContract(Name = "AWContract", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
    public interface IDemoContract
    {
        [OperationContract, WebGet]
        Stream GetImage();



        [OperationContract, WebGet(UriTemplate = "Product/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Product GetProduct(string id);


    }

    
}
