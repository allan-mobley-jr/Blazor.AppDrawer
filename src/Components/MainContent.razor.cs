// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;


namespace Blazor.MaterialDesign.Components
{
    /// <summary>
    /// Blazor component for adding scrollable main content when using the <see cref="AppContent"/> component in conjunction with the <see cref="AppDrawer"/> component.
    /// </summary>
    public partial class MainContent
    {
        /// <summary>
        /// All html attributes outside of the class attribute go here. Use the Class attribute property to add css classes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> ExtraAttributes { get; set; }

        /// <summary>
        /// The scrollable main content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Css classes for affecting this child component go here.
        /// </summary>
        [Parameter] public string Class { get; set; }
        
        /// <summary>
        /// Parent container.
        /// </summary>
        [CascadingParameter] protected AppContent Parent { get; set; }
    }
}