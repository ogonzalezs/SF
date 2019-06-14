using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace AT.Middleware.Service.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name
    //       "IService1" in both code and config file together.
    [ServiceContract]
    public interface IClient
    {
        [Description("Permite Obtener los datos de un Cliente.")]
        [WebInvoke(Method = "GET", UriTemplate = "/ClientByCardCode/{CardCode}")]
        string GetClient(long IdEmpresa,string CardCode);

        [Description("Permite Obtener los datos de los clientes.")]
        [WebInvoke(Method = "GET", UriTemplate = "/ClientAll/")]
        string GetClientAll(long IdEmpresa);
    }
}