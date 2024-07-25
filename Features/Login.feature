Feature: Login functionality

[AllureTag("login")]
  Scenario Outline: Successful login with valid credentials
    Given user navigate to login page on Browser
    When user enter valid username "<Username>" and password "<Password>"
    And user selects the login button
    Then DashboardPage should display
    Examples: 
    | Username | Password | 
    | Admin    | admin123 |
    | Admin1    | 121 |
