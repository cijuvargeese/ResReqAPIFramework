# ResReqAPIFramework
This C# automation framework automates API tests for the application https://reqres.in/. This API automation is achieved using the following tools
1. .net 5.0
2. RestSharp 105.3
3. SpecFlow 3.9.52
4. MS Test

# Installation of framework
1. Install Visual Studio 2019 or above
2. Install .net 5.0 
3. Install NugetPackages for RestSharp, Specflow, Specflow.MSTest
4. Install specflow extension by Extensions > Manage Extensions > Specflow > Install
5. Clone the repo from GitHub
6. Update the AppSettings.json with latest URLs or corresponding environment URLs
7. Run tests from test explorer.

# Parallel Execution 
The framework supports parallel execution in Scenario level(Class level). This is by default enabled. 
In order to achieve normal execution comment out lines in ParallelConfig.cs class

# Adding new tests
1. For adding new tests, specflow base knowledge is required. 
2. If its a new test for an existing feature, add a new scenario under existing feature in Gherkin language. Update the corresponding step definition classes.
3. While creating new feature files, respective step definition and implementation of these step definition should be done.
4. Make sure all the tests are passing after modifications.

# Note
All the passwords used in test are Base64 encrypted and should be provided as such, if not will cause in failure.

