using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CCD
{
    public partial class _Default : Page
    {

        public string accesstoken = string.Empty;
        HttpClient ccdclient = new HttpClient();                

        protected async void GetToken_Click(object sender, EventArgs e)
        {

            string ccdtokenurl = "https://login.microsoftonline.com/dc9ca558-84e5-4118-a993-ac96a3f4590f/oauth2/token";
            string clientId = "9f2a4449-0c4b-4019-9f28-ffc6b2f78039";
            string clientSecret = "1zI7Q~Xqt0OsQKEq6i9SXH7b6Zk9U6iBTCbPr";
            HttpRequestMessage tokenmessage = new HttpRequestMessage(HttpMethod.Post, ccdtokenurl);

            //adding body parameters in dictionary
            Dictionary<string, string> tokenbody = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "resource", "https://gfci-uat.sandbox.operations.dynamics.com" },
                { "client_secret", clientSecret },
                { "grant_type", "client_credentials" }
            };

            var content = new FormUrlEncodedContent(tokenbody);
            tokenmessage.Content = content;
            tokenmessage.Headers.Add("Host", "login.microsoftonline.com");
            var tokenresponse = await ccdclient.SendAsync(tokenmessage);
            string ccdtokenresponse = await tokenresponse.Content.ReadAsStringAsync();
            JObject jobj = JObject.Parse(ccdtokenresponse);
            accesstoken = (string)jobj["access_token"]; // get the token from response
            Label1.Text = accesstoken;     //just for demo purpose                    
        }

        protected void GetItems_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://gfci-uat.sandbox.operations.dynamics.com/data/CCD_CCItemDetails?cross-company=true");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            string tokenstr = "Bearer " + Label1.Text;
            request.AddHeader("Authorization", tokenstr);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            JObject getitemsobj = JObject.Parse(response.Content);

            //get all the values from response json
            var  allvalues = getitemsobj["value"];
            Label2.Text = allvalues.ToString();
            for(int i=0; i<allvalues.Count();i++)//loop through all values 
            {
                string currdataareaid = allvalues[i]["dataAreaId"].ToString();
                string currstatus = allvalues[i]["Status"].ToString();
                //get all the other required values like this
            }
           
        }
    }   
}