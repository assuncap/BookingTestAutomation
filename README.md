# BookingTestAutomation
Example of a Test automation framework developed by me. 
Presently the framework works with Selenium 3.x and NUnit 3. I will update to Selenium 4 shortly. 

## Architecture
The Solution is structured in 3 layers:
1. **Generic Framework Layer** - This Layer is used to facilitate re-use. Allowing for it to be used across multiple solutions. 
It contains Base classes for the implementation of Page Objects as well as Helpers and Extension Methods to inhance the standard behaviour of the 3rd party frameworks used.
2. **Page Objects Layer** - Onlike the Generic Framework Layer, this Layer is unlikelly to be re-used in other Solutions. It contains all the implementation to build the test scripts. Most of the code in the Layer uses the PageObject Design Pattern 
to map the different pages and elements.
3. **Test Scenarios Layer** - Contains all the Initialization code and all the test scripts

## Runsettings File
The [runsettings](https://docs.microsoft.com/en-us/visualstudio/test/configure-unit-tests-by-using-a-dot-runsettings-file?view=vs-2019) files allows us to define configuration settings for any of the layers test framework. Used correctly you can have the same test scripts against multiple enviroments just by using different configurations.  
For this project the parameters are:
1. **Enviroment** - Target url for the booking.com homepage.
2. **Browser** - Browser to be used to run the tests. Chrome and Firefox are supported at this point.

## How to Run the Tests
Load code in Visual Studio 2019 and run all test from the menu bar select *Test* > *Run All Test*. The runsettings file can be selected by navigating to *Test* > *Configure Run Settings* > *Select Solution wise runsettings file* on the menu bar.

