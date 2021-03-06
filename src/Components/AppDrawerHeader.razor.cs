// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using System.Collections.Generic;


namespace Mobsites.Blazor.MaterialDesign.Components
{
    /// <summary>
    /// Blazor child component for adding header content to the <see cref="AppDrawer"/> component.
    /// This will not scroll with the rest of the drawer content if placed as direct decendent of the <see cref="AppDrawer"/> component. 
    /// Things like account switchers and titles should live here.
    /// </summary>
    public partial class AppDrawerHeader
    {
        /// <summary>
        /// All html attributes outside of the class attribute go here. Use the Class attribute property to add css classes.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> ExtraAttributes { get; set; }

        /// <summary>
        /// The header content.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Css classes for affecting this child component go here.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Title content. Will be ignored if this component also has child content.
        /// </summary>
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// Subtitle content. Will be ignored if this component also has child content.
        /// </summary>
        [Parameter] public string Subtitle { get; set; }
        
        /// <summary>
        /// Image source override. Defaults to '_content/Mobsites.Blazor.MaterialDesign.AppDrawer/blazor.png'.
        /// Supply 'none' to ignore rendering img tag altogether.
        /// </summary>
        [Parameter] public string ImageSource { get; set; }
        
        /// <summary>
        /// Image width (px) override. Defaults to 192px.
        /// </summary>
        [Parameter] public int ImageWidth { get; set; }
        
        /// <summary>
        /// Image height (px) override. Defaults to 192px.
        /// </summary>
        [Parameter] public int ImageHeight { get; set; }
    }
}