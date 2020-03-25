// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.MaterialDesign.Components
{
    /// <summary>
    /// The Blazor AppDrawer component implements Google's MDC Navigation Drawer 
    /// and is used to organize access to destinations and other functionality on an app.
    /// </summary>
    public partial class AppDrawer
    {
        [Inject] protected IJSRuntime jsRuntime { get; set; }

        /// <summary>
        /// All html attributes outside of the class attribute go here. Use the Class attribute property to add css classes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> ExtraAttributes { get; set; } 

        /// <summary>
        /// The <see cref="AppDrawerHeader"/> (optional) and the <see cref="AppDrawerContent"/> (required).
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Css classes for affecting this component go here.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Set this to true to have a modal dismissable drawer across all device sizes. 
        /// Defaults to a responsive mode (false). 
        /// </summary>
        [Parameter] public bool ModalOnly { get; set; }

        /// <summary>
        /// The css media breakpoint (in pixels) at which the drawer goes from modal to fixed in responsive mode.
        /// The default is 900px, which also the minmum allowed.
        /// </summary>
        [Parameter] public int ResponsiveBreakpoint { get; set; }

        // Minimum breakpoint allowed.
        private const int responsiveBreakpoint = 900;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Refresh();
            }
        }

        /// <summary>
        /// Refreshes the drawer when in responsive mode.
        /// </summary>
        [JSInvokable]
        public async Task Refresh()
        {
            ResponsiveBreakpoint = ResponsiveBreakpoint > 900
                ? ResponsiveBreakpoint
                : responsiveBreakpoint;

            await jsRuntime.InvokeVoidAsync(
                "AppDrawer.init",
                DotNetObjectReference.Create(this),
                ModalOnly,
                ResponsiveBreakpoint);
        }
    }
}