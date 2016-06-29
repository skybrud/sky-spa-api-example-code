# Sky-spa-api-example-code

This repo is only containing examplecode for the API-part of a [Sky-SPA](https://github.com/skybrud/sky-spa)

## Intro
[Sky-SPA](https://github.com/skybrud/sky-spa) is an opensource Angular application for creating SPA (Single Page Application). SPA means a website with no full page request other than the initial request (ex. [http://www.ess-food.com/](http://www.ess-food.com/)). The rest of the pagerequests is done by routing in Angular and API-calls to the services behind. This examplecode shows how to make these APIs and connect them to an Umbraco instance.

<!-- list nuget dependencies -->
## NuGet Dependencies
For this code to work you need an Umbraco installation and The Skybrud.WebApi.Json NuGet package done by [Anders Bjerner](https://github.com/abjerner/). If you need to use Umbraco Grid, you also need Skybrud.Umbraco.GridData done by [Anders Bjerner](https://github.com/abjerner/).

1. [UmbracoCms](https://www.nuget.org/packages/UmbracoCms/) or if you do a code-project [UmbracoCms.Core](https://www.nuget.org/packages/UmbracoCms.Core/)
2. [Skybrud.WebApi.Json](https://www.nuget.org/packages/Skybrud.WebApi.Json/)
3. [Skybrud.Umbraco.GridData](https://github.com/skybrud/Skybrud.Umbraco.GridData) (optional)


## How to
When creating the backend part of a [Sky-SPA](https://github.com/skybrud/sky-spa) you need to take care of 4 different parts.

1. API´s connecting [Sky-SPA](https://github.com/skybrud/sky-spa) with Umbraco
2. Cache Invalidation (what to do when you make a new deploy of you JS files or what to do when the editor creates new content)
3. Initial response (main cshtml-template for the [Sky-SPA](https://github.com/skybrud/sky-spa))
4. How to send Grid-properties to [Sky-SPA](https://github.com/skybrud/sky-spa)


## 1. API´s
First of all you need to have 3 API´s for the [Sky-SPA](https://github.com/skybrud/sky-spa) to talk to Umbraco.

1. [NavigationApiController](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/api/Controllers/Api/Spa/NavigationApiController.cs)
The NavigationApiController is used to fetch navigationdata for the Sky-SPA 

2. [SettingsApiController](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/api/Controllers/Api/Spa/SettingsApiController.cs)
The SettingsApiController is used in the [StartView.cshtml](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/web/Views/StartView.cshtml), where we fetch the settingsdata you only wan´t to query once.

3. [ContentApiController]()
The ContentApiController is for fetching content-data when the user want´s to load a new page. It takes the current url as a parameter, and used Umbraco to find the data and return them as JSON.


## 2. Cache invalidation
Sky-SPA has build-in cacheinvalidation for both JS-assets and changes in Umbraco content. This is done so, that the application reacts on changes in your JS script file(s) and when an editor makes changes in Umbracos backoffice.

### 2.1 AssetsWatcher
[AssetsWatcher](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/api/EventHandlers/Spa/AssetsWatcher.cs) has to be registered in your Application startup file. If you don´t have one, use [this one](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/api/Startup.cs)

### 2.2 ContentWatcher
[ContentWatcher](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/api/EventHandlers/Spa/ContentWatcher.cs) also has to be registered in your Application startup file to work.


## 3. View (initial response template)
Your Umbraco installation is making the first request, when the user hits the site. All direct requests gives the user the same template, and Sky-SPA takes over and fetches the needed data via the API´s. You can find an example of a [start-template her](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/web/Views/StartView.cshtml). The [@Html.GetCacheableUrl extension you can find here](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/api/Extensions/HtmlHelperExtensions.cs). This extension handles cachebusting on assets.


## 4. Convert Griddata
