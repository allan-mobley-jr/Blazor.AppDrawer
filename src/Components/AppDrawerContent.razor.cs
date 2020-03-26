// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;


namespace Mobsites.Blazor.MaterialDesign.Components
{
    /// <summary>
    /// Blazor child component for adding scrollabel content to the <see cref="AppDrawer"/> component.
    /// Things like navigation destinations and other app functionality, such as a restart option, should live here.
    /// </summary>
    public partial class AppDrawerContent
    {
        /// <summary>
        /// All html attributes outside of the class attribute go here. Use the Class attribute property to add css classes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> ExtraAttributes { get; set; }

        /// <summary>
        /// The scrollabel content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Css classes for affecting this child component go here.
        /// </summary>
        [Parameter] public string Class { get; set; }
    }
}