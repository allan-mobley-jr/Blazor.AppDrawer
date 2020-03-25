# Blazor AppDrawer
This component library implements a subset of Google's [MDC Navigation Drawer](https://material.io/develop/web/components/drawers/) and is used to organize access to destinations and other functionality on an app.

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

After much thought, the full implementation of Google's MDC Navigation Drawer was (for now) decided against in favor of a mobile-first approach. The dismissible and permanent variants were left out, and only the modal variant and a hybrid variant called responsive made it in. (The responsive being the modal and fixed variants combined, transition occurring on a responsive media breakpoint.
