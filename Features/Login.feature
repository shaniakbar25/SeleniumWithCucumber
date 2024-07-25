Feature: Login functionality

[AllureTag("login")]
  Scenario Outline: Successful login with valid credentials
    Given user navigate to login page on Browser "<Browser>"
    When user enter valid username "<Username>" and password "<Password>"
    And user selects the login button
    Then DashboardPage should display
    Examples: 
    | Username | Password | Browser |
    | Admin    | admin123 | Chrome  |
    | Admin1    | 121 | Firefox |
