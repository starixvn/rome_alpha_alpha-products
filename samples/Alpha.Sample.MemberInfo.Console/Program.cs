namespace Alpha.Sample.MemberInfo.Console
{
    using System;
    using Integration;
    using Newtonsoft.Json;
    using Products.Core.Configuration;
    using Products.Core.Models;
    using Products.Core.Services;
    using Products.MemberInfo;
    using Products.MemberInfo.Requests;
    using Products.MemberInfo.ReviewSetting;
    using RemotingRef;
    using static StubCustomerProductStatusGetter;

    internal static class Program
    {
        private const int subAccountId = 0;

        private static void Main(string[] args)
        {
            try
            {
                StartConfiguration();
                ClearScreen();

                var actor = new Customer(1, subAccountId, "Actor_Name", 4, GetActorProductStatus());
                var upline = new Customer(3, subAccountId, "Upline_Name", 4, GetUplineProductStatus());
                var reviewedCustomer = new Customer(5, subAccountId, "Reviewed_Customer_Name", 3, GetReviewedCustomerProductStatus(), upline);

                LoadAndDisplayReviewSettingTabs(actor, reviewedCustomer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void StartConfiguration()
        {
            SimpleServiceLocator
                .Instance
                .Register<IConfigurationLoader>(new ReviewCustomerConfigurationLoader(new ProductJsonConverter()))
                .Register<Func<int, string>>(CacheRef.GetProductName)
                .Register<Func<string, string>>(Resource1.ResourceManager.GetString);
        }

        private static void ClearScreen()
        {
            CacheRef.GetProductName(1);
            Console.Clear();
        }

        private static void LoadAndDisplayReviewSettingTabs(ICustomer actor, ICustomer reviewedCustomer)
        {
            var viewModelfactory = new ReviewSettingViewModelFactory();

            var request = new ReviewSettingRequest(actor, reviewedCustomer);

            Console.WriteLine($"------------Review Setting Tabs------------\n");
            foreach (var viewModel in viewModelfactory.GetViewModels(request))
            {
                if (viewModel.Visible)
                {
                    Console.WriteLine(viewModel.Text);
                    Console.WriteLine(JsonConvert.SerializeObject(viewModel, Formatting.Indented));
                    Console.WriteLine();
                }
            }
        }
    }
}
