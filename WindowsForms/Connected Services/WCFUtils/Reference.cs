﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsForms.WCFUtils {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRoleGarage")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Option", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRoleGarage")]
    [System.SerializableAttribute()]
    public partial class Option : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CaracteristiqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PrixField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Caracteristique {
            get {
                return this.CaracteristiqueField;
            }
            set {
                if ((object.ReferenceEquals(this.CaracteristiqueField, value) != true)) {
                    this.CaracteristiqueField = value;
                    this.RaisePropertyChanged("Caracteristique");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom {
            get {
                return this.NomField;
            }
            set {
                if ((object.ReferenceEquals(this.NomField, value) != true)) {
                    this.NomField = value;
                    this.RaisePropertyChanged("Nom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Prix {
            get {
                return this.PrixField;
            }
            set {
                if ((this.PrixField.Equals(value) != true)) {
                    this.PrixField = value;
                    this.RaisePropertyChanged("Prix");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Vehicule", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRoleGarage")]
    [System.SerializableAttribute()]
    public partial class Vehicule : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategorieField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MarqueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NbRoueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WindowsForms.WCFUtils.Option[] OptionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PlaqueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Categorie {
            get {
                return this.CategorieField;
            }
            set {
                if ((object.ReferenceEquals(this.CategorieField, value) != true)) {
                    this.CategorieField = value;
                    this.RaisePropertyChanged("Categorie");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Marque {
            get {
                return this.MarqueField;
            }
            set {
                if ((object.ReferenceEquals(this.MarqueField, value) != true)) {
                    this.MarqueField = value;
                    this.RaisePropertyChanged("Marque");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Model {
            get {
                return this.ModelField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelField, value) != true)) {
                    this.ModelField = value;
                    this.RaisePropertyChanged("Model");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NbRoue {
            get {
                return this.NbRoueField;
            }
            set {
                if ((this.NbRoueField.Equals(value) != true)) {
                    this.NbRoueField = value;
                    this.RaisePropertyChanged("NbRoue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WindowsForms.WCFUtils.Option[] Options {
            get {
                return this.OptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.OptionsField, value) != true)) {
                    this.OptionsField = value;
                    this.RaisePropertyChanged("Options");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Plaque {
            get {
                return this.PlaqueField;
            }
            set {
                if ((this.PlaqueField.Equals(value) != true)) {
                    this.PlaqueField = value;
                    this.RaisePropertyChanged("Plaque");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Client", Namespace="http://schemas.datacontract.org/2004/07/WCFServiceWebRoleGarage")]
    [System.SerializableAttribute()]
    public partial class Client : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mail {
            get {
                return this.MailField;
            }
            set {
                if ((object.ReferenceEquals(this.MailField, value) != true)) {
                    this.MailField = value;
                    this.RaisePropertyChanged("Mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nom {
            get {
                return this.NomField;
            }
            set {
                if ((object.ReferenceEquals(this.NomField, value) != true)) {
                    this.NomField = value;
                    this.RaisePropertyChanged("Nom");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tel {
            get {
                return this.TelField;
            }
            set {
                if ((object.ReferenceEquals(this.TelField, value) != true)) {
                    this.TelField = value;
                    this.RaisePropertyChanged("Tel");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFUtils.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        WindowsForms.WCFUtils.CompositeType GetDataUsingDataContract(WindowsForms.WCFUtils.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<WindowsForms.WCFUtils.CompositeType> GetDataUsingDataContractAsync(WindowsForms.WCFUtils.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AjouterOption", ReplyAction="http://tempuri.org/IService/AjouterOptionResponse")]
        string AjouterOption(WindowsForms.WCFUtils.Option option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AjouterOption", ReplyAction="http://tempuri.org/IService/AjouterOptionResponse")]
        System.Threading.Tasks.Task<string> AjouterOptionAsync(WindowsForms.WCFUtils.Option option);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreerModel", ReplyAction="http://tempuri.org/IService/CreerModelResponse")]
        bool CreerModel(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreerModel", ReplyAction="http://tempuri.org/IService/CreerModelResponse")]
        System.Threading.Tasks.Task<bool> CreerModelAsync(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreerClient", ReplyAction="http://tempuri.org/IService/CreerClientResponse")]
        string CreerClient(WindowsForms.WCFUtils.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreerClient", ReplyAction="http://tempuri.org/IService/CreerClientResponse")]
        System.Threading.Tasks.Task<string> CreerClientAsync(WindowsForms.WCFUtils.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateDevis", ReplyAction="http://tempuri.org/IService/CreateDevisResponse")]
        string CreateDevis(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/CreateDevis", ReplyAction="http://tempuri.org/IService/CreateDevisResponse")]
        System.Threading.Tasks.Task<string> CreateDevisAsync(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SortieUsine", ReplyAction="http://tempuri.org/IService/SortieUsineResponse")]
        bool SortieUsine(int idVehicule, string plaque);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SortieUsine", ReplyAction="http://tempuri.org/IService/SortieUsineResponse")]
        System.Threading.Tasks.Task<bool> SortieUsineAsync(int idVehicule, string plaque);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WindowsForms.WCFUtils.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WindowsForms.WCFUtils.IService>, WindowsForms.WCFUtils.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public WindowsForms.WCFUtils.CompositeType GetDataUsingDataContract(WindowsForms.WCFUtils.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<WindowsForms.WCFUtils.CompositeType> GetDataUsingDataContractAsync(WindowsForms.WCFUtils.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string AjouterOption(WindowsForms.WCFUtils.Option option) {
            return base.Channel.AjouterOption(option);
        }
        
        public System.Threading.Tasks.Task<string> AjouterOptionAsync(WindowsForms.WCFUtils.Option option) {
            return base.Channel.AjouterOptionAsync(option);
        }
        
        public bool CreerModel(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client) {
            return base.Channel.CreerModel(vehicule, client);
        }
        
        public System.Threading.Tasks.Task<bool> CreerModelAsync(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client) {
            return base.Channel.CreerModelAsync(vehicule, client);
        }
        
        public string CreerClient(WindowsForms.WCFUtils.Client client) {
            return base.Channel.CreerClient(client);
        }
        
        public System.Threading.Tasks.Task<string> CreerClientAsync(WindowsForms.WCFUtils.Client client) {
            return base.Channel.CreerClientAsync(client);
        }
        
        public string CreateDevis(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client) {
            return base.Channel.CreateDevis(vehicule, client);
        }
        
        public System.Threading.Tasks.Task<string> CreateDevisAsync(WindowsForms.WCFUtils.Vehicule vehicule, WindowsForms.WCFUtils.Client client) {
            return base.Channel.CreateDevisAsync(vehicule, client);
        }
        
        public bool SortieUsine(int idVehicule, string plaque) {
            return base.Channel.SortieUsine(idVehicule, plaque);
        }
        
        public System.Threading.Tasks.Task<bool> SortieUsineAsync(int idVehicule, string plaque) {
            return base.Channel.SortieUsineAsync(idVehicule, plaque);
        }
    }
}
