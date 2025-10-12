using Management.Frontend.Repositories;
using Management.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Diagnostics.Metrics;

namespace Management.Frontend.Components.Pages.Employees
{
    public partial class EmployeeCreate
    {
        private Employee employee = new()
        {
            HireDate = DateTime.Now
        };

        [CascadingParameter] private IMudDialogInstance Dialog { get; set; } = default!;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/employees", employee);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                Snackbar.Add(message!, Severity.Error);
                return;
            }

            Snackbar.Add("Registro creado", Severity.Success);
            Dialog.Close(DialogResult.Ok(true));
        }

        private void Return()
        {
            Dialog.Cancel();
        }

    }
}