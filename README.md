# sky-spa-api
C# API for Sky-SPA

This repo is only containing examplecode for the API-part of a [Sky-SPA](https://github.com/skybrud/sky-spa)

<!-- short intro to Sky-SPA comes here -->


When creating the backend part of a [Sky-SPA](https://github.com/skybrud/sky-spa) you need to take care of x different parts.

1. API´s connecting [Sky-SPA](https://github.com/skybrud/sky-spa) with Umbraco content
2. Cache Invalidation (what to do when you make a new deploy of you JS files or what to do when the editor created new content)
3. Initial response (main cshtml-template for the [Sky-SPA](https://github.com/skybrud/sky-spa))
4. How to send Grid-properties to [Sky-SPA](https://github.com/skybrud/sky-spa)


## 1. API´s
First of all you need to have 3 API´s for the [Sky-SPA](https://github.com/skybrud/sky-spa) to talk to Umbraco.

1. [NavigationApiController](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/Skybrud.Umbraco.Spa.Core/Controllers/Api/Spa/NavigationApiController.cs)
The NavigationApiController is used to fetch navigationdata for the Sky-SPA 

2. [SettingsApiController](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/Skybrud.Umbraco.Spa.Core/Controllers/Api/Spa/SettingsApiController.cs)
The SettingsApiController is used in the [StartView.cshtml](https://github.com/skybrud/sky-spa-api-example-code/blob/master/src/Skybrud.Umbraco.Spa/SkySpaWebExample/Views/StartView.cshtml), where we fetch the settingsdata you only wan´t to query once.

3. [ContentApiController]()
The ContentApiController is for fetching content-data when the user want´s to load a new page. It takes the current url as a parameter, and used Umbraco to find the data and return them as JSON.
