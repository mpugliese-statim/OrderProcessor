using OrderProcessor.Models;

namespace OrderProcessor
{
    public class OrdersDataStore
    {
        public List<Order>? OrderTest { get; set; }

        public static OrdersDataStore OrderDataStoreTest { get; } = new OrdersDataStore();
               
        public OrdersDataStore()
        {
            OrderTest = new List<Order>();
            {
                new Order()
                {
                    AccountId = "The Account Id",
                    CallerInfo = new List<CallerInfo>()
                    {
                        new CallerInfo()
                        {
                            Email = "The User Email"
                        }
                    },
                    PickupAddress = new List<PickupAddress>()
                    {
                        new PickupAddress()
                        {
                            AddressLine1 = "7250 Rue du Mile End",
                            AddressLine2 = "Apcurium",
                            Company = null,
                            City = "Montréal",
                            PostalCode = "H2R 3A4",
                            StateProvince = "QC"
                        }
                    },
                    PickupLocation = new List<PickupLocation>()
                    {
                        new PickupLocation()
                        {
                            Latitude = 45.5316578,
                            Longitude = -73.622681
                        }
                    },
                    PickupContactInfo = new List<PickupContactInfo>()
                    {
                        new PickupContactInfo()
                        {
                            Id = null,
                            Name = "John Doe",
                            PhoneNumber = "7555-555-5555",
                            Email = "john@doe.com",
                            Language = "en"
                        }
                    },
                    PickupNotes = new List<PickupNotes>()
                    {
                        new PickupNotes()
                        {
                            Notes = "Please make sure that the number of items of the order is correct."
                        }
                    },
                    DeliveryAddress = new List<DeliveryAddress>()
                    {
                        new DeliveryAddress()
                        {
                            DeliveryAddressLine1 = "350 Rue Saint Paul Est",
                            DeliveryAddressLine2 = "Bonsecours Market",
                            Company = null,
                            City = "Montréal",
                            DeliveryPostalCode = "H2Y 1H2",
                            DeliveryStateProvince = "QC"
                        }
                    },
                    DeliveryLocation = new List<DeliveryLocation>()
                    {
                        new DeliveryLocation()
                        {
                            Latitude = 45.508971,
                            Longitude = -73.551493
                        }
                    },
                    DeliveryContactInfo = new List<DeliveryContactInfo>()
                    {
                        new DeliveryContactInfo()
                        {
                            Id = null,
                            Name = "François Cuvelier",
                            PhoneNumber = "555-555-5555",
                            Email = "franks@cuvelier.com",
                            Language = "fr"
                        }
                    },
                    DeliveryNotes = new List<DeliveryNotes>()
                    {
                        new DeliveryNotes()
                        {
                            DeliveryNotesContent = "Please make sure to deliver the right number of items.",
                            ReadyAt = "2025-01-30T16:05:14.3562962+00:00",
                            ReferenceNumber1 = "R003241948",
                            ReferenceNumber2 = "ABC128763",
                            ReferenceNumber3 = "15011496239",
                            Notes = "Ring the side door",
                            ServiceLevelId = "Your-Service-Level-ID",
                            CollectOnDelivery = 12.5,
                            AllowPartialCollectOnDelivery = true,
                            RequireIdentityValidation = true,
                            NumberOfPieces = 2,
                            Weight = 12,
                            VehicleTypeId = "CAR",
                            WebhookUrl = "http://your-callback-url.com/",
                        }
                    },
                    Metadata = new List<Metadata>()
                    {
                        new Metadata()
                        {
                            Metadata1 = "custom value1",
                            Metadata2 = "custom value2"
                        }
                    },
                    AttributeIds = new string[2]
                    {
                        "test1",
                        "test2"
                    },
                    ExtraFees = new List<ExtraFees>()
                    {
                       new ExtraFees
                       {
                            ExtraFeeId = "Extra Fee Id 1",
                            Quantity = 1,
                            UnitPrice = 10.5
                       },
                       new ExtraFees
                       {
                            ExtraFeeId = "Extra Fee Id 2",
                            Quantity = 1,
                            UnitPrice = 12.5
                       }
                    },
                    Workflows = new List<Workflows>()
                    {
                        new Workflows
                        {
                            Id = "The Workflow Id 1",
                            WorkflowType = 1,
                            WorkflowSteps = new WorkflowSteps()
                            {
                                StepId = "The Step Id 1",
                                SelectionStepId = null,
                                IsActive = true
                            }
                        },
                        new Workflows
                        {
                            Id = "The Workflow Id 2",
                            WorkflowType = 1,
                            WorkflowSteps = new WorkflowSteps()
                            {
                                StepId = "The Step Id 2",
                                SelectionStepId = null,
                                IsActive = true
                            }
                        }
                    },
                    UserFields = new List<UserFields>()
                    {
                        new UserFields
                        {
                            UserFieldId = "The User Field Id 1",
                            Value = "The UserField Value 1"
                        },
                        new UserFields
                        {
                            UserFieldId = "The User Field Id 2",
                            Value = "The UserField Value 2"
                        },
                    },
                    Items = new List<Items>()
                    {
                        new Items
                        {
                            BarcodeTemplate = null,
                            ParcelTypeId = "ParcelType Id 1",
                            Description = "Item Description 1",
                            Weight = 5,
                            Height = 5,
                            Length = 5,
                            Width = 5,
                            UserFields = new UserFields()
                            {
                                UserFieldId = "UserFieldId 1",
                                Value = "Value 1"
                            }
                        }
                    },
                    Hubs = new List<Hubs>()
                    {
                        new Hubs
                        {
                            AddressId = null,
                            Address = new Address
                            {
                                AddressLine1 = "5080 rue St Ambroise",
                                AddressLine2 = "Terrasse St-Ambroise",
                                Company = null,
                                PostalCode = "H4C 2G1",
                                StateProvince = "QC"
                            },
                            Location = new Location
                            {
                                Latitude = 45.46854715021447,
                                Longitude = -73.59099164603087
                            },
                            ContactInfo = new ContactInfo
                            {
                              Id = null,
                              Name = "Peter McAuslan",
                              PhoneNumber = "555-555-5555",
                              Email = "peter@emaildomain.com",
                              Language = "en"
                            },
                            LoadTimeInMinutes = 5,
                            Notes = "This is a note",
                            SegmentOverrideInfos = null
                        },
                    },
                    OrderPayout = new List<OrderPayout>()
                    { 
                        new OrderPayout
                        {
                            PredefinedPayoutValue = null,
                            DriverCommissionCalculationType = null,
                            OrderPayoutDelivery = new OrderPayoutDelivery
                            {
                                CalculationType = 0,
                                CommissionPercentage = null,
                                PredefinedPayoutValue = null,
                                FixedPayoutScheduleId = null
                            },
                            OrderPayoutFuelSurcharge = new OrderPayoutFuelSurcharge
                            {
                                CalculationType = 0,
                                CommissionPercentage = null,
                                PredefinedPayoutValue = null,
                                FixedPayoutScheduleId = null
                            },
                            OrderPayoutExtraFees = new OrderPayoutExtraFees
                            {
                                CalculationType = 0,
                                CommissionPercentage = null,
                                PredefinedPayoutValue = null,
                                FixedPayoutScheduleId = null
                            },
                            GenerateProofOfDeliveryOnDelivery = false
                        }
                    }
                };
            }
        }
    }
}
