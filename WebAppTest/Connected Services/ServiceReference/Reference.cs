﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicios.bcn.gob.ni/", ConfigurationName="ServiceReference.Tipo_Cambio_BCNSoap")]
    public interface Tipo_Cambio_BCNSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.bcn.gob.ni/RecuperaTC_Dia", ReplyAction="*")]
        double RecuperaTC_Dia(int Ano, int Mes, int Dia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.bcn.gob.ni/RecuperaTC_Dia", ReplyAction="*")]
        System.Threading.Tasks.Task<double> RecuperaTC_DiaAsync(int Ano, int Mes, int Dia);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento RecuperaTC_MesResult del espacio de nombres http://servicios.bcn.gob.ni/ no está marcado para convertirse en valor nulo
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.bcn.gob.ni/RecuperaTC_Mes", ReplyAction="*")]
        ServiceReference.RecuperaTC_MesResponse RecuperaTC_Mes(ServiceReference.RecuperaTC_MesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicios.bcn.gob.ni/RecuperaTC_Mes", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.RecuperaTC_MesResponse> RecuperaTC_MesAsync(ServiceReference.RecuperaTC_MesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RecuperaTC_MesRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RecuperaTC_Mes", Namespace="http://servicios.bcn.gob.ni/", Order=0)]
        public ServiceReference.RecuperaTC_MesRequestBody Body;
        
        public RecuperaTC_MesRequest()
        {
        }
        
        public RecuperaTC_MesRequest(ServiceReference.RecuperaTC_MesRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://servicios.bcn.gob.ni/")]
    public partial class RecuperaTC_MesRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Ano;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int Mes;
        
        public RecuperaTC_MesRequestBody()
        {
        }
        
        public RecuperaTC_MesRequestBody(int Ano, int Mes)
        {
            this.Ano = Ano;
            this.Mes = Mes;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class RecuperaTC_MesResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="RecuperaTC_MesResponse", Namespace="http://servicios.bcn.gob.ni/", Order=0)]
        public ServiceReference.RecuperaTC_MesResponseBody Body;
        
        public RecuperaTC_MesResponse()
        {
        }
        
        public RecuperaTC_MesResponse(ServiceReference.RecuperaTC_MesResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://servicios.bcn.gob.ni/")]
    public partial class RecuperaTC_MesResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public System.Xml.XmlElement RecuperaTC_MesResult;
        
        public RecuperaTC_MesResponseBody()
        {
        }
        
        public RecuperaTC_MesResponseBody(System.Xml.XmlElement RecuperaTC_MesResult)
        {
            this.RecuperaTC_MesResult = RecuperaTC_MesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface Tipo_Cambio_BCNSoapChannel : ServiceReference.Tipo_Cambio_BCNSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class Tipo_Cambio_BCNSoapClient : System.ServiceModel.ClientBase<ServiceReference.Tipo_Cambio_BCNSoap>, ServiceReference.Tipo_Cambio_BCNSoap
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Tipo_Cambio_BCNSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(Tipo_Cambio_BCNSoapClient.GetBindingForEndpoint(endpointConfiguration), Tipo_Cambio_BCNSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Tipo_Cambio_BCNSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Tipo_Cambio_BCNSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Tipo_Cambio_BCNSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Tipo_Cambio_BCNSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Tipo_Cambio_BCNSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public double RecuperaTC_Dia(int Ano, int Mes, int Dia)
        {
            return base.Channel.RecuperaTC_Dia(Ano, Mes, Dia);
        }
        
        public System.Threading.Tasks.Task<double> RecuperaTC_DiaAsync(int Ano, int Mes, int Dia)
        {
            return base.Channel.RecuperaTC_DiaAsync(Ano, Mes, Dia);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ServiceReference.RecuperaTC_MesResponse ServiceReference.Tipo_Cambio_BCNSoap.RecuperaTC_Mes(ServiceReference.RecuperaTC_MesRequest request)
        {
            return base.Channel.RecuperaTC_Mes(request);
        }
        
        public System.Xml.XmlElement RecuperaTC_Mes(int Ano, int Mes)
        {
            ServiceReference.RecuperaTC_MesRequest inValue = new ServiceReference.RecuperaTC_MesRequest();
            inValue.Body = new ServiceReference.RecuperaTC_MesRequestBody();
            inValue.Body.Ano = Ano;
            inValue.Body.Mes = Mes;
            ServiceReference.RecuperaTC_MesResponse retVal = ((ServiceReference.Tipo_Cambio_BCNSoap)(this)).RecuperaTC_Mes(inValue);
            return retVal.Body.RecuperaTC_MesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.RecuperaTC_MesResponse> ServiceReference.Tipo_Cambio_BCNSoap.RecuperaTC_MesAsync(ServiceReference.RecuperaTC_MesRequest request)
        {
            return base.Channel.RecuperaTC_MesAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.RecuperaTC_MesResponse> RecuperaTC_MesAsync(int Ano, int Mes)
        {
            ServiceReference.RecuperaTC_MesRequest inValue = new ServiceReference.RecuperaTC_MesRequest();
            inValue.Body = new ServiceReference.RecuperaTC_MesRequestBody();
            inValue.Body.Ano = Ano;
            inValue.Body.Mes = Mes;
            return ((ServiceReference.Tipo_Cambio_BCNSoap)(this)).RecuperaTC_MesAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.Tipo_Cambio_BCNSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.Tipo_Cambio_BCNSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.Tipo_Cambio_BCNSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://servicios.bcn.gob.ni/Tc_Servicio/ServicioTC.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.Tipo_Cambio_BCNSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://servicios.bcn.gob.ni/Tc_Servicio/ServicioTC.asmx");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            Tipo_Cambio_BCNSoap,
            
            Tipo_Cambio_BCNSoap12,
        }
    }
}
