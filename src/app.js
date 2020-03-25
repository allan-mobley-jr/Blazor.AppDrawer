// Copyright (c) 2020 Allan Mobley. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

import {MDCDrawer} from "@material/drawer/index";
import {MDCList} from "@material/list/index";

let modalEventsInitialized = false;
let resizeEventInitialized = false;

window.AppDrawer = {
    init: function (instance, modalOnly, breakpoint) {
        window.AppDrawer.instance = instance;
        // Initialize either modal or responsive drawer.
        if (modalOnly) {
            window.AppDrawer.self = initModalDrawer();
        }
        else {
            // Toggle between permanent drawer and modal drawer at breakpoint 900px.
            window.AppDrawer.self = window.matchMedia('(max-width: ' + breakpoint + 'px)').matches 
                ? initModalDrawer() 
                : initPermanentDrawer();
            resizeEventInitialized = resizeEventInitialized || initResizeEvent();
        }
        modalEventsInitialized = modalEventsInitialized || initModalEvents();
    }
}

const initModalDrawer = () => {
    // Fetch drawer element.
    const drawerElement = document.querySelector('.mdc-drawer');

    // Add modal influence.
    drawerElement.classList.add('mdc-drawer--modal');

    // Show drawer button.
    document.querySelector('.mdc-top-app-bar__navigation-icon, .app-drawer-button').classList.remove('hide-drawer-button');

    // Modal uses the MDCDrawer component, which will instantiate MDCList automatically.
    const drawer = MDCDrawer.attachTo(drawerElement);
    drawer.open = false;

    return drawer;
}
  
const initPermanentDrawer = () => {
    // Remove any modal influence.
    document.querySelector('.mdc-drawer').classList.remove('mdc-drawer--modal');

    // Hide drawer button.
    document.querySelector('.mdc-top-app-bar__navigation-icon, .app-drawer-button').classList.add('hide-drawer-button');

    // For permanently visible drawer, the list must be instantiated for appropriate keyboard interaction.
    const list = new MDCList(document.querySelector('.mdc-drawer .mdc-list, .mdc-drawer .mdc-drawer__content'));
    list.wrapFocus = true;

    return list;
}

const initModalEvents = () => {
    // Event for closing modal drawer when navigation occurs.
    const listEl = document.querySelector('.mdc-drawer .mdc-list, .mdc-drawer .mdc-drawer__content');
    listEl.addEventListener('click', (event) => {
        window.AppDrawer.self.open = false;
    });

    // Event for toggling modal drawer when .app-drawer-button class is specified.
    // Note: Blazor.MaterialDesign.Components.TopAppBar itself will initialize this event when employed.
    var drawerButton = document.querySelector('.app-drawer-button');
    if (drawerButton)
    {
        drawerButton.addEventListener('click', (event) => {
            window.AppDrawer.self.open = !window.AppDrawer.self.open;
        });
    }

    return true;
}
  
const initResizeEvent = () => {
    window.addEventListener('resize', resizeHandler);
    return true;
}
  
const resizeHandler = () => { 
    window.AppDrawer.self.destroy();
    window.AppDrawer.instance.invokeMethodAsync('Refresh');
}