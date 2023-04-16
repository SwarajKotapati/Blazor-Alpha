using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary1
{
    public class ShowConfirmationBase : ComponentBase
    {
        public bool ShowConfirmation { get; set; } = false;

        [Parameter]
        public string ModalHeader { get; set; } = "Confirm Delete";

        [Parameter]
        public string ModalBody { get; set; } = "Delete employee permanenetly ?";

        [Parameter]

        public EventCallback<bool> ButtonClickedEvent { get; set; }

        public void ShowConfirmationModal()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        public async Task ButtonClicked(bool b)
        {
            ShowConfirmation = false;
            await ButtonClickedEvent.InvokeAsync(b);
        }

    }
}
