using System;
using System.Data;
using System.ServiceModel;
using ConsoleApplication1.EConsentServices;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EndpointAddress endpoint = new EndpointAddress(new Uri("http://devsp1.atbapps.com:6139/ConsentFormSvc.svc/basic?wsdl"));
            var consentFormSvcClient = new ConsentFormSvcClient(new BasicHttpBinding(), endpoint);
            foreach (DataRow row in consentFormSvcClient.GetPatientfromLocation("BHE").Rows)
            {
            }
        }
    }
}