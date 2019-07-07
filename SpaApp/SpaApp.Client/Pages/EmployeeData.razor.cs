using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SpaApp.Shared;

namespace SpaApp.Client.Pages
{
    public class EmployeeDataComponent : ComponentBase
    {
        [Inject]
        protected HttpClient HttpClient { get; set; }

        protected List<Employee> employees = new List<Employee>();

        protected Employee employee = new Employee();

        protected string modalTitle { get; set; }

        protected async override Task OnInitAsync()
        {
            await this.GetAllEmployees();
        }

        protected async Task GetAllEmployees()
        {
            this.employees = await this.HttpClient.GetJsonAsync<List<Employee>>("api/employees");
        }

        protected void AddEmployee()
        {
            this.employee = new Employee();
            this.modalTitle = "Add Employee";
        }

        protected async Task EditEmployee(string id)
        {
            this.employee = await this.HttpClient.GetJsonAsync<Employee>($"/api/employees/{id}");
            this.modalTitle = "Edit Employee";
        }

        protected async Task SaveEmployee()
        {
            //string json = JsonConvert.SerializeObject(this.employee);
            await this.HttpClient.PutJsonAsync<Employee>("api/employees", this.employee);
            await this.GetAllEmployees();
        }

        protected async Task DeleteEmployee(string id)
        {
            this.modalTitle = "Delete Employee";
            await this.HttpClient.DeleteAsync($"/api/employees/{id}");
            await this.GetAllEmployees();
        }

        protected async Task ConfirmDelete(string id)
        {
            this.modalTitle = "Confirm Delete?";
            this.employee = await this.HttpClient.GetJsonAsync<Employee>($"/api/employees/{id}");
        }
    }
}
