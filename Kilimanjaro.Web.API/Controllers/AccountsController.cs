using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kilimanjaro.Web.API.Model;
using Kilimanjaro.Domain;
using Kilimanjaro.Application;
//using Kilimanjaro.Application.Model;
using Kilimanjaro.RepositoryEF;
using Kilimanjaro.RepositoryEF.Repository;
using Kilimanjaro.Application.Model;
using Kilimanjaro.Domain.Contract;

namespace Kilimanjaro.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        
        private readonly ApplicationCustomer applicationCustomer;
        
        public AccountsController()
        {
            //ConstructorApplication application = new ConstructorApplication();
            //string obaOba = application.ApplicationCustomerEFNew();

            string obaOba = ConstructorApplication.ApplicationCustomerEFNew();

            applicationCustomer = ConstructorApplication.ApplicationCustomerEF();

            string teste = "OKOKOK";

            string teste12 = "OKOKOK12";

            //applicationCustomer = ConstructorApplication.ApplicationCustomerEF();
        }


        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IEnumerable<string> m_oEnum = new List<string>() { "GIVE", "DIVE", "NIVE" };
            return m_oEnum;
        }
        */

        [HttpGet]
        public IEnumerable<AccountTest> Get()
        {
            IEnumerable<AccountTest> list = applicationCustomer.ListAll();
            return list;
        }

        /*

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return new List<Account>
            {
                new Account
                {
                    AccountNumber ="0001",
                    BankName ="Dummy Bank",
                    CustomerAddress = new Address117
                    {
                        Address1="address1",
                        Address2 ="address2",
                        Country ="US",
                        PostalCode ="20877",
                        State ="MD"
                    },
                    CustomerId ="Customer001",
                    CustomerName ="John Sherman"
                },
                new Account{ AccountNumber="0002",
                    BankName ="Dummy Bank",
                    CustomerAddress = new Address117
                    {
                        Address1="address3",
                        Address2 ="address4",
                        Country ="US",
                        PostalCode ="20877",
                        State ="MD"
                    },
                    CustomerId ="Customer002",
                    CustomerName ="Marie Curie"
                }
            };
        }
        */
        
        [HttpGet("{acctNumber}")]
        public Account Get(string acctNumber)
        {

            return new Account
            {
                AccountNumber = "0001",
                BankName = "Dummy Bank",
                CustomerAddress = null,
                CustomerId = "Customer001",
                CustomerName = "John Sherman"
            };

            /*
            return new Account
            {
                AccountNumber = "0001",
                BankName = "Dummy Bank",
                CustomerAddress = new Address
                {
                    Address1 = "address1",
                    Address2 = "address2",
                    Country = "US",
                    PostalCode = "20877",
                    State = "MD"
                },
                CustomerId = "Customer001",
                CustomerName = "John Sherman"
            };
            */
        }

        [HttpPost]
        public ActionResult Post([FromBody]Account account)
        {
            return Created(Request.QueryString.Value, account);
        }

        [HttpPut("{acctNumber}")]
        public ActionResult Put(string acctNumber,
        [FromBody]string account)
        {
            return Ok("Account with account number: " + acctNumber + " has been updated!");
        }

        [HttpDelete("{acctNumber}")]
        public ActionResult Delete(string acctNumber)
        {
            return Ok("Account with account number: " + acctNumber + " has been deleted!");
        }
        
    }
}
