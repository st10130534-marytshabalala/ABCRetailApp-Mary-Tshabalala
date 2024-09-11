namespace ABCRetailApp_Mary_Tshabalala.services
{
    using ABCRetailApp_Mary_Tshabalala.Models;
    using Azure.Data.Tables;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TableStorageService
    {
        private readonly TableServiceClient _tableServiceClient;

        public TableStorageService(TableServiceClient tableServiceClient)
        {
            _tableServiceClient = tableServiceClient;
        }

        public async Task AddCustomerAsync(customerprofile customer)
        {
            var tableClient = _tableServiceClient.GetTableClient("customerprofile");
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync(customer);
        }

        public async Task<IEnumerable<customerprofile>> GetCustomersAsync()
        {
            var tableClient = _tableServiceClient.GetTableClient("customerprofile");
            var query = tableClient.QueryAsync<customerprofile>();
            List<customerprofile> customers = new List<customerprofile>();

            await foreach (var customer in query)
            {
                customers.Add(customer);
            }

            return customers;
        }
    }

}
