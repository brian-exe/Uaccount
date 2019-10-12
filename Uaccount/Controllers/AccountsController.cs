using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uaccount.Model;
using RestSharp;

namespace Uaccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string user_id)
        {
            var client = new RestClient();
            var request = new RestRequest(Method.GET);

            request.Resource = "https://sandbox.bind.com.ar/v1/banks/322/accounts/owner";
            request.RequestFormat = DataFormat.Json;
            string MyToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJxVjhWQ2tvY05KSmNDaXd1VFBlTEtRemVBMFZ0d0g4alVIeUtWU0l3YnlrPSIsImNyZWF0ZWQiOjE1NzA4NjUxMDc2MzEsIm5hbWUiOiJFemVxdWllbCBBY2lhciIsImV4cCI6MTU3MDg5MzkwN30.HATfoE4pt1KOpqOlX4BeIUsXdXvABjRaOMMU_tqN4gehJ0BdidaNz4xlIOajs-2bj1YlzJGZuaaOr3_X4MdbfA";
            request.AddHeader("Authorization", "JWT " + MyToken);

            IRestResponse response = client.Execute(request);
            List <Model.Account> userObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Account>>(response.Content);
            List<Model.AccountResponse> listResponse = new List<Model.AccountResponse>();

            try
            {
                foreach (Model.Account acc in userObj)
                {
                    AccountResponse aux = new AccountResponse();
                    aux.amount = acc.balance.amount;
                    aux.bank = "BIND";
                    aux.type = acc.type;
                    aux.cbu = acc.account_routing.address;
                    aux.id = acc.id;
                    listResponse.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            listResponse.AddRange(GetFakeAccounts());
            return JsonConvert.SerializeObject(listResponse);
        }

        private List<AccountResponse> GetFakeAccounts()
        {
            List<AccountResponse> list = new List<AccountResponse>();
            list.Add(new AccountResponse() {
                amount = 11111.2,
                bank = "SANTANDER",
                type = "Cuenta Corriente",
                cbu = "ABCDEFGHIJKL1234",
                id = "1234",
            });

            return list;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
