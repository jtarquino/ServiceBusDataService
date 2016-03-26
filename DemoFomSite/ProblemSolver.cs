using System;
using System.ServiceModel;
using System.ServiceModel.Web;

class ProblemSolver : IProblemSolver
{
    public string CurrentTime()
    {
        return DateTime.Now.ToString();
    }
}