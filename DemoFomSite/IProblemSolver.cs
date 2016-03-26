using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract(Namespace = "urn:ps")]
interface IProblemSolver
{
    [OperationContract, WebGet]
    string CurrentTime();
}

