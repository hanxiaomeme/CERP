﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LanyunLanyunMES.UI.UserManager {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserManager.UserManager")]
    public interface UserManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserManager/U8Login", ReplyAction="http://tempuri.org/UserManager/U8LoginResponse")]
        MES.Server.Model.User U8Login(string userName, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserManager/U8LoginSer", ReplyAction="http://tempuri.org/UserManager/U8LoginSerResponse")]
        string U8LoginSer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UserManager/GetFtpUser", ReplyAction="http://tempuri.org/UserManager/GetFtpUserResponse")]
        MES.Server.Model.FtpUser GetFtpUser();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UserManagerChannel : LanyunLanyunMES.UI.UserManager.UserManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserManagerClient : System.ServiceModel.ClientBase<LanyunLanyunMES.UI.UserManager.UserManager>, LanyunLanyunMES.UI.UserManager.UserManager {
        
        public UserManagerClient() {
        }
        
        public UserManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MES.Server.Model.User U8Login(string userName, string pwd) {
            return base.Channel.U8Login(userName, pwd);
        }
        
        public string U8LoginSer() {
            return base.Channel.U8LoginSer();
        }
        
        public MES.Server.Model.FtpUser GetFtpUser() {
            return base.Channel.GetFtpUser();
        }
    }
}
