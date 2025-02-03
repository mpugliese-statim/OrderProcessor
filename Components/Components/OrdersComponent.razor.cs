using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OrderProcessor.Components.Pages;
using OrderProcessor.Models;

namespace OrderProcessor.Components.Components
{
    public partial class OrdersComponent : ComponentBase
    {
        public string? TestValue { get; set; }

        public string? TestValueAddr { get; set; }
        public string? TestJsonCallerInfo { get; set; }
        public string? TestJsonPickupAddr { get; set; }
        public string? TestJsonPickupLoc { get; set; }

        public JsonResult? JsonResultTest { get; set; }
       
        public Order OrderResults { get; set; } = new Order();

        protected override void OnInitialized()
        {
            //ShowMsg();
            ShowJson();
        }

        public void ShowMsg()
        {
            TestValue = "Order has been cancelled";
        }

        public string ShowJson()
        {
            //JsonResult jsonResult = new JsonResult(OrdersDataStore.OrderDataStoreTest);

            //Order? orderResult = JsonSerializer.Deserialize<Order>(jsonResult.ToString());

            //JsonResultTest = new JsonResult(
            //                   new List<object>
            //                   {
            //                        new { AccountId = "1234" }
            //                   });

            var TestOrder = new
            {
                AddressId = @"123-CO-XYZ",
                CallerInfo = new List<CallerInfo>()
                {
                    new CallerInfo()
                    {
                        Email = "jsmith@gmail.com"
                    }
                },
                PickupAddress = new List<PickupAddress>()
                {
                    new PickupAddress()
                    {
                        AddressLine1 = "7250 Broadway Blvd",
                        AddressLine2 = "Suite 10",
                        Company = "Test Company XYZ",
                        City = "Denver",
                        PostalCode = "80014",
                        StateProvince = "CO"
                    }
                },
                PickupLocation = new List<PickupLocation>()
                {
                    new PickupLocation()
                    {
                        Latitude = 45.5316578,
                        Longitude = -73.622681
                    }
                }
            };

            string jsonData = JsonConvert.SerializeObject(TestOrder);

            JObject jsonObject = JObject.Parse(jsonData);

            TestValueAddr = jsonObject["AddressId"]?.ToString();
            TestJsonCallerInfo = jsonObject["CallerInfo"]?.ToString();
            TestJsonPickupAddr = jsonObject["PickupAddress"]?.ToString();
            TestJsonPickupLoc = jsonObject["PickupLocation"]?.ToString();

            return TestValue;
        }
    }
}
