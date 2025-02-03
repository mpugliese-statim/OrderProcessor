using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using OrderProcessor.Models;
using System.Text.Json;

namespace OrderProcessor.Components.Components
{
    public partial class OrdersComponent : ComponentBase
    {
        private List<IBrowserFile> loadedFiles = [];
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        private bool isLoading;
        private decimal progressPercent;

        IWebHostEnvironment? Environment;
        ILogger? Logger;

        public string? TestValue { get; set; }
        public string? TestValueAddr { get; set; }
        public string? TestJsonCallerInfo { get; set; }
        public string? TestJsonPickupAddr { get; set; }
        public string? TestJsonPickupAddr2 { get; set; }
        public string? TestJsonPickupAddrCo { get; set; }
        public string? TestJsonPickupAddrCity { get; set; }
        public string? TestJsonPickupAddrZip { get; set; }
        public string? TestJsonPickupAddrSt { get; set; }
        public string? TestJsonPickupLocLat { get; set; }
        public string? TestJsonPickupLocLong { get; set; }
        public string? TestJsonPickupContactInfoId { get; set; }
        public string? TestJsonPickupContactInfoName { get; set; }
        public string? TestJsonPickupContactInfoPhone { get; set; }
        public string? TestJsonPickupContactInfoEmail { get; set; }
        public string? TestJsonPickupContactInfoLanguage { get; set; }
        public string? TestJsonPickupNotes { get; set; }
        public string? TestJsonDeliveryAddr1 { get; set; }
        public string? TestJsonDeliveryAddr2 { get; set; }
        public string? TestJsonDeliveryAddrCo { get; set; }
        public string? TestJsonDeliveryAddrCity { get; set; }
        public string? TestJsonDeliveryAddrZip { get; set; }
        public string? TestJsonDeliveryAddrSt { get; set; }
        public string? TestJsonDeliveryLocLat { get; set; }
        public string? TestJsonDeliveryLocLong { get; set; }
        public string? TestJsonDeliveryContactInfoId { get; set; }
        public string? TestJsonDeliveryContactInfoName { get; set; }
        public string? TestJsonDeliveryContactInfoPhone { get; set; }
        public string? TestJsonDeliveryContactInfoEmail { get; set; }
        public string? TestJsonDeliveryContactInfoLanguage { get; set; }
        public string? TestJsonOrderStatusValue { get; set; }
        public string? TestJsonOrderStatus { get; set; }
        public string? FileUploadResults { get; set; }
        public JsonResult? JsonResultTest { get; set; }
       
        public Order OrderResults { get; set; } = new Order();

        protected override void OnInitialized()
        { }

        public void PopulateOrderView(string file)
        {
            JsonDocument? jd = JsonDocument.Parse(File.ReadAllText("C:\\FileUpload\\" + file));
            JsonElement jeAcctId = jd.RootElement.GetProperty("AccountId");
            // CallerInfo
            Object jeCallInfoEmail = jd.RootElement.GetProperty("CallerInfo").GetProperty("email");
            // PickupAddress
            Object jePickupAddr1 = jd.RootElement.GetProperty("PickupAddress").GetProperty("addressLine1");
            Object jePickupAddr2 = jd.RootElement.GetProperty("PickupAddress").GetProperty("addressLine2");
            Object jePickupAddrCo = jd.RootElement.GetProperty("PickupAddress").GetProperty("company");
            Object jePickupAddrCity = jd.RootElement.GetProperty("PickupAddress").GetProperty("city");
            Object jePickupAddrZip = jd.RootElement.GetProperty("PickupAddress").GetProperty("postalCode");
            Object jePickupAddrSt = jd.RootElement.GetProperty("PickupAddress").GetProperty("stateProvince");
            // PickupLocation
            Object jePickupLocLat = jd.RootElement.GetProperty("PickupLocation").GetProperty("latitude");
            Object jePickupLocLong = jd.RootElement.GetProperty("PickupLocation").GetProperty("longitude");
            // PickupContactInfo
            Object jePickupContactInfoId = jd.RootElement.GetProperty("PickupContactInfo").GetProperty("id");
            Object jePickupContactInfoName = jd.RootElement.GetProperty("PickupContactInfo").GetProperty("name");
            Object jePickupContactInfoPhone = jd.RootElement.GetProperty("PickupContactInfo").GetProperty("phoneNumber");
            Object jePickupContactInfoEmail = jd.RootElement.GetProperty("PickupContactInfo").GetProperty("email");
            Object jePickupContactInfoLanguage = jd.RootElement.GetProperty("PickupContactInfo").GetProperty("language");
            // Pickupnotes
            Object jePickupNotes = jd.RootElement.GetProperty("PickupNotes");
            // DeliveryAddress
            Object jeDeliveryAddr1 = jd.RootElement.GetProperty("DeliveryAddress").GetProperty("addressLine1");
            Object jeDeliveryAddr2 = jd.RootElement.GetProperty("DeliveryAddress").GetProperty("addressLine2");
            Object jeDeliveryAddrCo = jd.RootElement.GetProperty("DeliveryAddress").GetProperty("company");
            Object jeDeliveryAddrCity = jd.RootElement.GetProperty("DeliveryAddress").GetProperty("city");
            Object jeDeliveryAddrZip = jd.RootElement.GetProperty("DeliveryAddress").GetProperty("postalCode");
            Object jeDeliveryAddrSt = jd.RootElement.GetProperty("DeliveryAddress").GetProperty("stateProvince");
            // DeliveryLocation
            Object jeDeliveryLocLat = jd.RootElement.GetProperty("DeliveryLocation").GetProperty("latitude");
            Object jeDeliveryLocLong = jd.RootElement.GetProperty("DeliveryLocation").GetProperty("longitude");
            // DeliveryContactInfo
            Object jeDeliveryContactInfoId = jd.RootElement.GetProperty("DeliveryContactInfo").GetProperty("id");
            Object jeDeliveryContactInfoName = jd.RootElement.GetProperty("DeliveryContactInfo").GetProperty("name");
            Object jeDeliveryContactInfoPhone = jd.RootElement.GetProperty("DeliveryContactInfo").GetProperty("phoneNumber");
            Object jeDeliveryContactInfoEmail = jd.RootElement.GetProperty("DeliveryContactInfo").GetProperty("email");
            Object jeDeliveryContactInfoLanguage = jd.RootElement.GetProperty("DeliveryContactInfo").GetProperty("language");

            // Populate values on Orders page
            TestValueAddr = jeAcctId.ToString();
            TestJsonCallerInfo = jeCallInfoEmail.ToString();
            TestJsonPickupAddr = jePickupAddr1.ToString();
            TestJsonPickupAddr2 = jePickupAddr2.ToString();
            TestJsonPickupAddrCo = jePickupAddrCo.ToString();
            TestJsonPickupAddrCity = jePickupAddrCity.ToString();
            TestJsonPickupAddrZip = jePickupAddrZip.ToString();
            TestJsonPickupAddrSt = jePickupAddrSt.ToString();
            TestJsonPickupLocLat = jePickupLocLat.ToString();
            TestJsonPickupLocLong = jePickupLocLong.ToString();
            TestJsonPickupContactInfoId = jePickupContactInfoId.ToString();
            TestJsonPickupContactInfoName = jePickupContactInfoName.ToString();
            TestJsonPickupContactInfoPhone = jePickupContactInfoPhone.ToString();
            TestJsonPickupContactInfoEmail = jePickupContactInfoEmail.ToString();
            TestJsonPickupContactInfoLanguage = jePickupContactInfoLanguage.ToString();
            TestJsonPickupNotes = jePickupNotes.ToString();
            TestJsonDeliveryAddr1 = jeDeliveryAddr1.ToString();
            TestJsonDeliveryAddr2 = jeDeliveryAddr2.ToString();
            TestJsonDeliveryAddrCo = jeDeliveryAddrCo.ToString();
            TestJsonDeliveryAddrCity = jeDeliveryAddrCity.ToString();
            TestJsonDeliveryAddrZip = jeDeliveryAddrZip.ToString();
            TestJsonDeliveryAddrSt = jeDeliveryAddrSt.ToString();
            TestJsonDeliveryLocLat = jeDeliveryLocLat.ToString();
            TestJsonDeliveryLocLong = jeDeliveryLocLong.ToString();
            TestJsonDeliveryContactInfoId = jeDeliveryContactInfoId.ToString();
            TestJsonDeliveryContactInfoName = jeDeliveryContactInfoName.ToString();
            TestJsonDeliveryContactInfoPhone = jeDeliveryContactInfoPhone.ToString();
            TestJsonDeliveryContactInfoEmail = jeDeliveryContactInfoEmail.ToString();
            TestJsonDeliveryContactInfoLanguage = jeDeliveryContactInfoLanguage.ToString();

            if (file != null)
            {
                FileUploadResults = "File Uploaded Successfully";
            }   
        }

        public async Task LoadFiles(InputFileChangeEventArgs e)
        {
            isLoading = true;
            loadedFiles.Clear();
            progressPercent = 0;

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                try
                {
                    var trustedFileName = Path.GetRandomFileName();
                    //var path = Path.Combine(Environment.ContentRootPath,
                    //    Environment.EnvironmentName, "unsafe_uploads", trustedFileName);

                    var path = Path.Combine(trustedFileName);

                    await using FileStream writeStream = new(path, FileMode.Create);
                    using var readStream = file.OpenReadStream(maxFileSize);
                    var bytesRead = 0;
                    var totalRead = 0;
                    var buffer = new byte[1024 * 10];

                    while ((bytesRead = await readStream.ReadAsync(buffer)) != 0)
                    {
                        totalRead += bytesRead;
                        await writeStream.WriteAsync(buffer, 0, bytesRead);
                        progressPercent = Decimal.Divide(totalRead, file.Size);
                        StateHasChanged();
                    }

                    loadedFiles.Add(file);

                    var fileload = loadedFiles[0];

                    var filename = fileload.Name;

                    // Filename is loaded, now remove file
                    loadedFiles.RemoveAt(0);

                    PopulateOrderView(filename);
                }

                catch (Exception ex)
                {
                    throw new Exception("The following error occurred.", ex);
                }
            }
        }
    }
}
