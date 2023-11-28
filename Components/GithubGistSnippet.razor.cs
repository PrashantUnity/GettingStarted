using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GettingStarted.Components
{
    public partial class GithubGistSnippet
    {
        private IJSObjectReference? module;

        protected string Id = Guid.NewGuid().ToString();

        [Inject] private IJSRuntime JSRuntime { get; set; } = default!;

        [Parameter, EditorRequired] public string Title { get; set; } = default!;
        [Parameter, EditorRequired] public string UserId { get; set; } = default!;
        [Parameter, EditorRequired] public string FileName { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/githubgist.js");

            await module.InvokeVoidAsync("printSnippetFrom", Id, UserId, FileName);
        } 
    }
}
