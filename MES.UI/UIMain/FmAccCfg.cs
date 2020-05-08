using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace LanyunMES.UI
{
    public partial class FmAccCfg : DevComponents.DotNetBar.OfficeForm
    {
        public FmAccCfg()
        {
            InitializeComponent();
            this.Load += FormLoad;
        }

        private string operation;

        private void FormLoad(object sender, EventArgs e)
        {
            var str = GetEndpointAddress("BasicHttpBinding_UserManager").Replace("http://", "");
            string[] arry = str.Split(new char[] { '/' });
            
            txt_IPAddress.Text = arry[0];
            operation = arry[1];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string address = txt_IPAddress.Text.Trim();
            this.SetEndpointAddress(address);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// ∂¡»°EndpointAddress
        /// </summary>
        private string GetEndpointAddress(string endpointName)
        {
            ClientSection clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
            foreach (ChannelEndpointElement item in clientSection.Endpoints)
            {
                if (item.Name == endpointName)
                    return item.Address.ToString();
            }
            return string.Empty;
        }


        /// <summary>
        /// …Ë÷√EndpointAddress
        /// </summary>
        private void SetEndpointAddress(string address)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ClientSection clientSection = config.GetSection("system.serviceModel/client") as ClientSection;

            address = "http://" + address;
            foreach (ChannelEndpointElement item in clientSection.Endpoints)
            {
                string newAddress = address + ":" + item.Address.Port + item.Address.AbsolutePath;
                item.Address = new Uri(newAddress);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("system.serviceModel");
        }
         
    }
}