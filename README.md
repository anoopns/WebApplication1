# WebApplication1

Description

The project was created using .NET Framework MVC application. The challenge asked to list the number of days where the temperature is predicated to be above 20 degrees, however, I had to make it >10 due to the response I get from the API. 

Structure:

I leveraged the default folder structure by adding the below,
Controller:

ForeCastController
DataModel:

Forecast - defines the processed data from API response which is passed to the View
This also includes a class, ‘ForecastBusinessLayer’ that handles the business logic. The method ‘GetWeatherForecast’ hit the API with required parameters. It then processes the response and create list data objects to be passed to the view. 

App settings (Web.config):
Values for URL, APPID & query parameters 
View:
Renders the data passed from the Controller

How to run the App:
1.	Clone the repo https://github.com/anoopns/WebApplication1.git
2.	Build the project
3.	Run the app using IIS Express (You will be asked to install the certificate for the first time you run it)
 
4.	This will launch the app in browser (https://localhost:44387/)
5.	Append ‘Forecast’ to the base URL and this will take you to the screen that displays weather data
 

Things that can be approved:
1.	Better error handling – currently the app will not give any details if API doesn’t respond


References I used:
1.	https://dotnettutorials.net/lesson/asp-dot-net-mvc-architecture/
2.	https://stackoverflow.com/
3.	https://www.tutorialsteacher.com/webapi/consume-web-api-get-method-in-aspnet-mvc

