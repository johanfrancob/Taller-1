using Management.Frontend.Repositories;
using Management.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.Metrics;

namespace Management.Frontend.Components.Pages.Employees
{

    public partial class EmployeeEdit
    {

        private Employee? employee;

        [CascadingParameter] private IMudDialogInstance Dialog { get; set; } = default!;


        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;

        [Parameter] public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<Employee>($"api/employees/{Id}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("employee");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    Snackbar.Add(messageError!, Severity.Error);
                }
            }
            else
            {
                employee = responseHttp.Response;
                StateHasChanged(); 

            }
        }

        private async Task EditAsync()
        {
            var responseHttp = await Repository.PutAsync("api/employees", employee);

            if (responseHttp.Error)
            {
                var messageError = await responseHttp.GetErrorMessageAsync();
                Snackbar.Add(messageError!, Severity.Error);
                return;
            }

            Snackbar.Add("Registro guardado.", Severity.Success);
            Dialog.Close(DialogResult.Ok(true));


        }

        private void Return()
        {
            Dialog.Cancel();                      
        }
    }
}