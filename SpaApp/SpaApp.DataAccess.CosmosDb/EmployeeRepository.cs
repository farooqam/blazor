using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using SpaApp.Shared;
using SpaApp.Shared.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaApp.DataAccess.CosmosDb
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Container container;
        private readonly CosmosDbOptions options; 

        public EmployeeRepository(CosmosClient cosmosClient, IOptions<CosmosDbOptions> options)
        {
            this.container = cosmosClient.GetContainer(options.Value.DatabaseName, options.Value.CollectionName);
            this.options = options.Value;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            ItemResponse<Employee> response = await this.container.CreateItemAsync(employee, new PartitionKey(employee.id));
            return response.Resource;
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            ItemResponse<Employee> response = await this.container.DeleteItemAsync<Employee>(id: id, partitionKey: new PartitionKey(id));
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            QueryDefinition query = new QueryDefinition("select * from employees s");
            FeedIterator<Employee> resultSet = this.container.GetItemQueryIterator<Employee>(query);
            List<Employee> allEmployees = new List<Employee>();

            while (resultSet.HasMoreResults)
            {
                IEnumerable<Employee> employees = (await resultSet.ReadNextAsync()).Resource;
                allEmployees.AddRange(employees);
            }

            return allEmployees;
        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            ItemResponse<Employee> response = await this.container.ReadItemAsync<Employee>(id: id, partitionKey: new PartitionKey(id));
            return response.Resource;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            ItemResponse<Employee> response = await this.container.UpsertItemAsync<Employee>(item: employee, partitionKey: new PartitionKey(employee.id));
            return response.Resource;
        }
    }
}
