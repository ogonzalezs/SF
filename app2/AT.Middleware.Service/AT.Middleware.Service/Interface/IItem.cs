using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace AT.Middleware.Service.Interface
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de
    //       interfaz "IItem" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IItem
    {
        [Description("Permite Obtener los datos de un Articulo.")]
        [WebInvoke(Method = "GET", UriTemplate = "/ItemByItemCode/{ItemCode}")]
        string GetItem(long IdEmpresa, string ItemCode);

        [Description("Permite Obtener los datos de los Articulos.")]
        [WebInvoke(Method = "GET", UriTemplate = "/ItemAll/")]
        string GetItemAll(long IdEmpresa);

        [Description("Permite Obtener los datos de un Articulo y su lista de precio.")]
        [WebInvoke(Method = "GET", UriTemplate = "/ItemByPriceList/{ItemCode}/{PriceList}")]
        string GetItemByPriceList(long IdEmpresa, string ItemCode, string PriceList);

    }
}