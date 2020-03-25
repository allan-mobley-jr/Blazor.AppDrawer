# Blazor AppDrawer
This component library implements a subset of Google's [MDC Navigation Drawer](https://material.io/develop/web/components/drawers/) and is used to organize access to destinations and other functionality on an app.

<image src="src/assets/modal-only-mode.png" alt="Image of Modal Only Mode" width="165" height="" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<image src="src/assets/responsive-mode.png" alt="Image of Responsive Mode" width="650" height="" />

## For
* Blazor webassembly
* Blazor server

## Dependencies

###### .NETStandard 2.0
* Microsoft.AspNetCore.Components (>= 3.1.2)
* Microsoft.AspNetCore.Components.Web (>= 3.1.2)

## Design and Development
The design and development of this component library was heavily guided by Steve Sanderson's [talk](https://youtu.be/QnBYmTpugz0) and [example](https://github.com/SteveSandersonMS/presentation-2020-01-NdcBlazorComponentLibraries), in which he outlines the best approach to building and deploying a reusable component library.

As for the non-C# implementation of this component library, obviously Google's MDC Navigation Drawer [docs](https://material.io/develop/web/components/drawers/) were consulted.

After much thought, the full implementation of Google's MDC Navigation Drawer was (for now) decided against in favor of a mobile-first approach. As a result, the dismissible and permanent variants were left out, and only the modal variant and a hybrid variant called responsive made it in. (The responsive being the modal and fixed variants combined, transition occurring on a responsive media breakpoint.

Also, unlike some of the other MDC drawer components out there for Blazor, this one was designed without requiring the user to wire up an onclick event handler or a callback function for toggling of the drawer in modal mode. The component works seamlessly with `Blazor TopAppBar`, or, as the samples demonstrate, by simply applying a couple of css classes.

## Getting Started
1. Install [Nuget](https://www.nuget.org/packages/Mobsites.Blazor.MaterialDesign.AppDrawer/):

```shell
dotnet add package Mobsites.Blazor.MaterialDesign.AppDrawer --version 1.0.0-preview1
```

2. Add the following link tag to `index.html` (webassembly) or `_Host.cshtml` (server) just above the closing `</head>` tag along with your other link tags:

```html
<link href="_content/Mobsites.Blazor.MaterialDesign.AppDrawer/bundle.css" rel="stylesheet" />
```

3. Add the following script tag to `index.html` (webassembly) or `_Host.cshtml` (server) just above the closing `</body>` tag along with your other script tags:

```html
<script src="_content/Mobsites.Blazor.MaterialDesign.AppDrawer/bundle.js"></script>
```

4. Add the following markup to the `MainLayout.razor` file (ideally):

```html
<!-- Add optional app bar here or below -->
<AppDrawer ModalOnly="true">
    <!-- The header is optional. Place outside of <AppDrawerContent></AppDrawerContent> to avoid scrolling. -->
    <AppDrawerHeader>
        <!-- All child tags are optional -->
        <img src="" width="192" height="192" />
        <AppDrawerHeaderTitle Class="text-light"><!-- Add text --></AppDrawerHeaderTitle>
        <AppDrawerHeaderSubtitle Class="text-light"><!-- Add text --></AppDrawerHeaderSubtitle>
    </AppDrawerHeader>
    <!-- Required -->
    <AppDrawerContent>
        <!-- Add navigation content or app functionality here -->
        <!-- Scrollable content (separate from scrollable content in <MainContent></MainContent>)  -->
    </AppDrawerContent>
</AppDrawer>
<!-- Required for responsive mode, recommended for modal only mode -->
<AppContent>

    <!-- Add optional app bar here (be sure to set <AppContent ContainsAppBar="true"> above) -->

    <!-- Scrollable content (separate from scrollable content in <AppDrawerContent></AppDrawerContent>)  -->
    <MainContent>
        <!-- typically @Body -->
    </MainContent>
</AppContent>
```

***Note the flag set on `<AppDrawer ModalOnly="true">`. For responsive mode, set to `false` or leave attribute off altogether.***

5. Add `Blazor TopAppBar` component or custom app bar (shown below). This can be placed above the `<AppDrawer></AppDrawer>` element or inside the `<AppContent></AppContent>` element:

```html
<div class="app-bar">
    <button class="app-drawer-button mr-auto" >
        <span class="oi oi-menu"></span>
    </button>
    <a href="http://blazor.net" target="_blank" class="ml-md-auto">About</a>
</div>
```

***Note the use of the two css classes `.app-bar` and `.app-drawer-button` above. The latter class is wired up to toggle the drawer on button click. Neither class is necessary when using `Blazor TopAppBar`.***

## Possible CSS Styling Conflicts

This component defaults to the below css style rules, which may conflict with what you already have in place. These styles are necessary for the responsive mode to work properly. Modal drawers are elevated above most of the app’s UI and generally don’t affect the screen’s layout grid, so you should be able to get by if changing any of these defaults when using the modal only mode.

```css
body {
    display: flex;
    height: 100vh;
}

app {
    position: relative;
    display: flex;
    flex-direction: column;
    width: 100%;
}
  
.mdc-drawer-app-content {
    flex: auto;
    overflow: auto;
    position: relative;
}

.main-content {
    overflow: auto;
    height: 100%;
    padding-left: 2rem !important;
    padding-right: 1.5rem !important;
    padding-top: 4.5rem;
}

@media (min-width: 768px) {
    app {
        flex-direction: row;
    }
}
```
