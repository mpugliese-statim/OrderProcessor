﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using OrderProcessor.Helper;
using OrderProcessor.Models;
using System.Text.Json;
using System.Xml;

namespace OrderProcessor.Components.Components
{
    public partial class OrdersComponent : ComponentBase
    {
        private List<IBrowserFile> loadedFiles = [];
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 5;
        private bool isLoading;
        private decimal progressPercent;

        IWebHostEnvironment? Environment;
        ILogger? Logger;

        OrderClassMembers OrderClassMembers { get; set; } = new OrderClassMembers();
        public string? TestJsonOrderStatus { get; set; }
        public string? FileUploadResults { get; set; }
        public Order OrderResults { get; set; } = new Order();
        public string[]? FileEntries { get; set; }
        public ChangeEventArgs? ChangeEventArgs { get; set; }
        public InputFileChangeEventArgs? InputFileChangeEventArgs { get; set; }
        public string? file { get; set; }
        public string[]? files { get; set; }
        public string? SelectedVal { get; set; }
        public bool? ShowResults { get; set; } = false;
        
        protected override void OnInitialized()
        {
            LoadFileDropDown(e: ChangeEventArgs);
        }

        public void LoadFileDropDown(ChangeEventArgs e)
        {
            string fileDir = @"C:\FileUpload\";

            FileEntries = Directory.GetFiles(fileDir);
        }

        public void DropDownItemSelected(ChangeEventArgs e)
        {
            SelectedVal = e?.Value?.ToString();
        }

        public void PopulateOrderViewJSON(string file)
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
            // Delivery Notes and assorted delivery values
            Object jeDeliveryNotes = jd.RootElement.GetProperty("DeliveryNotes");
            Object jeReadyAt = jd.RootElement.GetProperty("ReadyAt");
            Object jeRefNum1 = jd.RootElement.GetProperty("ReferenceNumber1");
            Object jeRefNum2 = jd.RootElement.GetProperty("ReferenceNumber2");
            Object jeRefNum3 = jd.RootElement.GetProperty("ReferenceNumber3");
            Object jeNotes = jd.RootElement.GetProperty("Notes");
            Object jeServiceLvlId = jd.RootElement.GetProperty("ServiceLevelId");
            Object jeCollectOnDel = jd.RootElement.GetProperty("CollectOnDelivery");
            Object jeAllowPartialCol = jd.RootElement.GetProperty("AllowPartialCollectOnDelivery");
            Object jeRequireIdVal = jd.RootElement.GetProperty("RequireIdentityValidation");
            Object jeNumOfPieces = jd.RootElement.GetProperty("NumberOfPieces");
            Object jeWeight = jd.RootElement.GetProperty("Weight");
            Object jeVehicleTypeId = jd.RootElement.GetProperty("VehicleTypeId");
            Object jeWebhookUrl = jd.RootElement.GetProperty("WebhookUrl");

            // Populate values on Orders page
            OrderClassMembers.TestValueAddr = jeAcctId.ToString();
            OrderClassMembers.TestJsonCallerInfo = jeCallInfoEmail.ToString();
            OrderClassMembers.TestJsonPickupAddr = jePickupAddr1.ToString();
            OrderClassMembers.TestJsonPickupAddr2 = jePickupAddr2.ToString();
            OrderClassMembers.TestJsonPickupAddrCo = jePickupAddrCo.ToString();
            OrderClassMembers.TestJsonPickupAddrCity = jePickupAddrCity.ToString();
            OrderClassMembers.TestJsonPickupAddrZip = jePickupAddrZip.ToString();
            OrderClassMembers.TestJsonPickupAddrSt = jePickupAddrSt.ToString();
            OrderClassMembers.TestJsonPickupLocLat = jePickupLocLat.ToString();
            OrderClassMembers.TestJsonPickupLocLong = jePickupLocLong.ToString();
            OrderClassMembers.TestJsonPickupContactInfoId = jePickupContactInfoId.ToString();
            OrderClassMembers.TestJsonPickupContactInfoName = jePickupContactInfoName.ToString();
            OrderClassMembers.TestJsonPickupContactInfoPhone = jePickupContactInfoPhone.ToString();
            OrderClassMembers.TestJsonPickupContactInfoEmail = jePickupContactInfoEmail.ToString();
            OrderClassMembers.TestJsonPickupContactInfoLanguage = jePickupContactInfoLanguage.ToString();
            OrderClassMembers.TestJsonPickupNotes = jePickupNotes.ToString();
            OrderClassMembers.TestJsonDeliveryAddr1 = jeDeliveryAddr1.ToString();
            OrderClassMembers.TestJsonDeliveryAddr2 = jeDeliveryAddr2.ToString();
            OrderClassMembers.TestJsonDeliveryAddrCo = jeDeliveryAddrCo.ToString();
            OrderClassMembers.TestJsonDeliveryAddrCity = jeDeliveryAddrCity.ToString();
            OrderClassMembers.TestJsonDeliveryAddrZip = jeDeliveryAddrZip.ToString();
            OrderClassMembers.TestJsonDeliveryAddrSt = jeDeliveryAddrSt.ToString();
            OrderClassMembers.TestJsonDeliveryLocLat = jeDeliveryLocLat.ToString();
            OrderClassMembers.TestJsonDeliveryLocLong = jeDeliveryLocLong.ToString();
            OrderClassMembers.TestJsonDeliveryContactInfoId = jeDeliveryContactInfoId.ToString();
            OrderClassMembers.TestJsonDeliveryContactInfoName = jeDeliveryContactInfoName.ToString();
            OrderClassMembers.TestJsonDeliveryContactInfoPhone = jeDeliveryContactInfoPhone.ToString();
            OrderClassMembers.TestJsonDeliveryContactInfoEmail = jeDeliveryContactInfoEmail.ToString();
            OrderClassMembers.TestJsonDeliveryContactInfoLanguage = jeDeliveryContactInfoLanguage.ToString();
            OrderClassMembers.TestJsonDeliveryNotes = jeDeliveryNotes.ToString();
            OrderClassMembers.TestJsonReadyAt = jeReadyAt.ToString();
            OrderClassMembers.TestJsonRefNum1 = jeRefNum1.ToString();
            OrderClassMembers.TestJsonRefNum2 = jeRefNum2.ToString();
            OrderClassMembers.TestJsonRefNum3 = jeRefNum3.ToString();
            OrderClassMembers.TestJsonNotes = jeNotes.ToString();
            OrderClassMembers.TestJsonServiceLvlId = jeServiceLvlId.ToString();
            OrderClassMembers.TestJsonCollectOnDelivery = jeCollectOnDel.ToString();
            OrderClassMembers.TestJsonAllowPartialColOnDel = jeAllowPartialCol.ToString();
            OrderClassMembers.TestJsonRequireIdVal = jeRequireIdVal.ToString();
            OrderClassMembers.TestJsonNumOfPieces = jeNumOfPieces.ToString();
            OrderClassMembers.TestJsonWeight = jeWeight.ToString();
            OrderClassMembers.TestJsonVehicleTypeId = jeVehicleTypeId.ToString();
            OrderClassMembers.TestJsonWebhookUrl = jeWebhookUrl.ToString();

            if (file != null)
            {
                FileUploadResults = "File Uploaded Successfully";
                ShowResults = true;
            }
        }

        public void PopulateOrderViewXML(string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\FileUpload\\" + file);
            
            // AcctId
            OrderClassMembers.TestValueAcctId = xmlDoc?.DocumentElement?.FirstChild?.InnerText;
            // CallerInfo
            OrderClassMembers.TestJsonCallerInfo = xmlDoc?.DocumentElement?.SelectSingleNode("//CallerId/email")?.InnerText;
            // PickupAddress
            OrderClassMembers.TestJsonPickupAddr = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupAddress/addressLine1")?.InnerText;
            OrderClassMembers.TestJsonPickupAddr2 = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupAddress/addressLine2")?.InnerText;
            OrderClassMembers.TestJsonPickupAddrCo = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupAddress/company")?.InnerText;
            OrderClassMembers.TestJsonPickupAddrCity = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupAddress/city")?.InnerText;
            OrderClassMembers.TestJsonPickupAddrZip = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupAddress/postalCode")?.InnerText;
            OrderClassMembers.TestJsonPickupAddrSt = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupAddress/stateProvince")?.InnerText;
            // PickupLocation
            OrderClassMembers.TestJsonPickupLocLat = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupLocation/latitude")?.InnerText;
            OrderClassMembers.TestJsonPickupLocLong = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupLocation/longitude")?.InnerText;
            // PickupContactInfo
            OrderClassMembers.TestJsonPickupContactInfoId = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupContactInfo/id")?.InnerText;
            OrderClassMembers.TestJsonPickupContactInfoName = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupContactInfo/name")?.InnerText;
            OrderClassMembers.TestJsonPickupContactInfoPhone = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupContactInfo/phoneNumber")?.InnerText;
            OrderClassMembers.TestJsonPickupContactInfoEmail = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupContactInfo/email")?.InnerText;
            OrderClassMembers.TestJsonPickupContactInfoLanguage = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupContactInfo/language")?.InnerText;
            // PickupNotes
            OrderClassMembers.TestJsonPickupNotes = xmlDoc?.DocumentElement?.SelectSingleNode("//PickupNotes")?.InnerText;
            // DeliveryAddress
            OrderClassMembers.TestJsonDeliveryAddr1 = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryAddress/addressLine1")?.InnerText;
            OrderClassMembers.TestJsonDeliveryAddr2 = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryAddress/addressLine2")?.InnerText;
            OrderClassMembers.TestJsonDeliveryAddrCo = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryAddress/company")?.InnerText;
            OrderClassMembers.TestJsonDeliveryAddrCity = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryAddress/city")?.InnerText;
            OrderClassMembers.TestJsonDeliveryAddrZip = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryAddress/postalCode")?.InnerText;
            OrderClassMembers.TestJsonDeliveryAddrSt = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryAddress/stateProvince")?.InnerText;
            // DeliveryLocation
            OrderClassMembers.TestJsonDeliveryLocLat = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryLocation/latitude")?.InnerText;
            OrderClassMembers.TestJsonDeliveryLocLong = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryLocation/longitude")?.InnerText;
            // DeliveryContactInfo
            OrderClassMembers.TestJsonDeliveryContactInfoId = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryContactInfo/id")?.InnerText;
            OrderClassMembers.TestJsonDeliveryContactInfoName = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryContactInfo/name")?.InnerText;
            OrderClassMembers.TestJsonDeliveryContactInfoPhone = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryContactInfo/phoneNumber")?.InnerText;
            OrderClassMembers.TestJsonDeliveryContactInfoEmail = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryContactInfo/email")?.InnerText;
            OrderClassMembers.TestJsonDeliveryContactInfoLanguage = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryContactInfo/language")?.InnerText;
            // DeliveryNotes
            OrderClassMembers.TestJsonDeliveryNotes = xmlDoc?.DocumentElement?.SelectSingleNode("//DeliveryNotes")?.InnerText;
            // ReadyAt
            OrderClassMembers.TestJsonReadyAt = xmlDoc?.DocumentElement?.SelectSingleNode("//ReadyAt")?.InnerText;
            // RefNum1
            OrderClassMembers.TestJsonRefNum1 = xmlDoc?.DocumentElement?.SelectSingleNode("//ReferenceNumber1")?.InnerText;
            // RefNum2
            OrderClassMembers.TestJsonRefNum2 = xmlDoc?.DocumentElement?.SelectSingleNode("//ReferenceNumber2")?.InnerText;
            // RefNum3
            OrderClassMembers.TestJsonRefNum3 = xmlDoc?.DocumentElement?.SelectSingleNode("//ReferenceNumber3")?.InnerText;
            // Notes
            OrderClassMembers.TestJsonNotes = xmlDoc?.DocumentElement?.SelectSingleNode("//Notes")?.InnerText;
            // ServiceLevelId
            OrderClassMembers.TestJsonServiceLvlId = xmlDoc?.DocumentElement?.SelectSingleNode("//ServiceLevelId")?.InnerText;
            // CollectOnDelivery
            OrderClassMembers.TestJsonCollectOnDelivery = xmlDoc?.DocumentElement?.SelectSingleNode("//CollectOnDelivery")?.InnerText;
            // AllowPartialCollectOnDelivery
            OrderClassMembers.TestJsonAllowPartialColOnDel = xmlDoc?.DocumentElement?.SelectSingleNode("//AllowPartialCollectOnDelivery")?.InnerText;
            // RequireIdentityValidation
            OrderClassMembers.TestJsonRequireIdVal = xmlDoc?.DocumentElement?.SelectSingleNode("//RequireIdentityValidation")?.InnerText;
            // NumberOfPieces
            OrderClassMembers.TestJsonNumOfPieces = xmlDoc?.DocumentElement?.SelectSingleNode("//NumberOfPieces")?.InnerText;
            // Weight
            OrderClassMembers.TestJsonWeight = xmlDoc?.DocumentElement?.SelectSingleNode("//Weight")?.InnerText;
            // VehicleTypeId
            OrderClassMembers.TestJsonVehicleTypeId = xmlDoc?.DocumentElement?.SelectSingleNode("//VehicleTypeId")?.InnerText;
            // WebhookUrl
            OrderClassMembers.TestJsonWebhookUrl = xmlDoc?.DocumentElement?.SelectSingleNode("//WebhookUrl")?.InnerText;
            // Metadata
            OrderClassMembers.TestJsonMetadata1 = xmlDoc?.DocumentElement?.SelectSingleNode("//Metadata/metadata1")?.InnerText;
            OrderClassMembers.TestJsonMetadata2 = xmlDoc?.DocumentElement?.SelectSingleNode("//Metadata/metadata2")?.InnerText;


            if (file != null)
            {
                FileUploadResults = "File Uploaded Successfully";
                ShowResults = true;
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
                    var path = Path.Combine(file.ToString());

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

                    var fileExt = Path.GetExtension(file.Name);

                    if (fileExt == ".json")
                    {
                        PopulateOrderViewJSON(file.Name);
                    }
                    else if (fileExt == ".xml")
                    {
                        PopulateOrderViewXML(file.Name);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error occurred.", ex);
                }
            }
        }
    }
}
