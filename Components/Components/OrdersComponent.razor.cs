using System.Collections.Immutable;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OrderProcessor.Components.Pages;
using OrderProcessor.Models;

namespace OrderProcessor.Components.Components
{
    public partial class OrdersComponent : ComponentBase
    {
        public string? TestValue { get; set; }

        public Order OrderResults { get; set; } = new Order();

        protected override void OnInitialized()
        {
            ShowMsg();
            ShowJson();
        }

        public void ShowMsg()
        {
            TestValue = "Order has been cancelled";
        }

        public Task<ActionResult<Order>> ShowJson()
        {
            //return new JsonResult(value: OrdersDataStore.OrderDataStoreTest.OrderTest);
            return null;
        }
    }
}
