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


