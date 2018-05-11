namespace Alpha.Sample.AccountInfo.Console
{
    using System;
    using System.Collections.Generic;
    using Alpha.Products.AccountInfo;
    using Alpha.Products.AccountInfo.Requests;
    using Alpha.Products.AccountInfo.Status;
    using Alpha.Products.Core.Configuration;
    using Alpha.Products.Core.Models;
    using Alpha.Products.Core.Services;
    using Alpha.RemotingRef;
    using Alpha.Sample.AccountInfo.Console.Integration;
    using Newtonsoft.Json.Linq;
    using Products.AccountInfo.Setting;

    using static StubCustomerProductStatusGetter;

    internal static class Program
    {
        private const int subAccountId = 0;

        private static void Main()
        {
            try
            {
                StartConfiguration();

                ClearScreen();

                var actor = new Customer(1, subAccountId, "Actor_Name", 4, GetActorProductStatus());
                var upline = new Customer(3, subAccountId, "Upline_Name", 4, GetUplineProductStatus());
                var searchAccount = new Customer(5, subAccountId, "Search_Account_Name", 3, GetSearchAccountProductStatus(), upline);

                LoadAndDisplaySettingOnAccountInfoPanel(actor, searchAccount);

                LoadAndDisplayStatusOnAccountInfoPanel(actor, searchAccount);
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
            .Register<Func<IEnumerable<IConfigurationItem>>>(ProductConfiguration.LoadApplicationProductConfiguration)
            .Register<Func<int, string>>(CacheRef.GetProductName)
            .Register<Func<string, string>>(Resource1.ResourceManager.GetString);
        }

        private static void ClearScreen()
        {
            CacheRef.GetProductName(1);
            Console.Clear();
        }

        private static void LoadAndDisplaySettingOnAccountInfoPanel(ICustomer actor, ICustomer searchAccount)
        {
            var viewModelfactory = new SettingViewModelFactory();

            var request = new SearchAccountRequest(actor, searchAccount);

            request
                .AddData(Constants.Actor_CanEditDailyTransferOption, true)
                .AddData(Constants.Actor_HasUpdateAccountPermission, true);

            Console.WriteLine($"------------Account Info Edit Setting------------\n");
            foreach (var viewModel in viewModelfactory.GetViewModels(request))
            {
                if (viewModel.Visible)
                {
                    Console.WriteLine(viewModel.Text);
                    Console.WriteLine(viewModel);
                    Console.WriteLine();
                }
            }
        }

        private static void LoadAndDisplayStatusOnAccountInfoPanel(ICustomer actor, ICustomer searchAccount)
        {
            var viewModelfactory = new StatusViewModelFactory();

            Console.WriteLine($"------------Account Info Edit Status------------\n");

            var request = new SearchAccountRequest(actor, searchAccount);

            request
                .AddData(Constants.Actor_HasUpdateAccountPermission, true)

                .AddData(Constants.SearchAccount_IsAllowedMasterAutoPT, true)

                .AddData(Constants.SearchAccount_Upline_IsAllowedOutright, true)
                .AddData(Constants.SearchAccount_IsAllowedOutright, true)

                .AddData(Constants.SearchAccount_Upline_IsClosed, true)
                .AddData(Constants.SearchAccount_IsClosed, true)

                .AddData(Constants.SearchAccount_Upline_IsAllowedDoubleComm, true)
                .AddData(Constants.SearchAccount_IsAllowedDoubleComm, true)

                .AddData(Constants.SearchAccount_Upline_IsSuspended, true)
                .AddData(Constants.SearchAccount_IsSuspended, true);

            foreach (var viewModel in viewModelfactory.GetViewModels(request))
            {
                if (viewModel.Visible)
                {
                    Console.WriteLine(viewModel.Text);
                    Console.WriteLine(viewModel);
                    Console.WriteLine();
                }
            }
        }
    }
}