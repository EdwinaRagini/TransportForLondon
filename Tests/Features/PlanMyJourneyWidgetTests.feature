@planmyjourney
Feature: PlanMyJourneyWidgetTests

Cookies are accepted before each scenario 

Scenario Outline: Verify that a valid journey can be planned using the widget
	Given I enter the From and To Locations
	| From Location  | To Location  |
	| <FromLocation> | <ToLocation> |
	When I click on plan my journey button
	Then I verify the details in journey results

	Examples: 
	| FromLocation                      | ToLocation                 |
	| Oxford Circus Underground Station | London Gatwick Airport     |
	| Heathrow Airport Terminal 4       | Sutton Common Rail Station |

Scenario Outline: Verify that the widget is unable to provide results when one or more invalid locations are used
	Given I enter the From and To Locations
	| From Location  | To Location  |
	| <FromLocation> | <ToLocation> |
	When I click on plan my journey button
	Then I verify the error messages in Journey Results page
	| Error          |
	| <ErrorMessage> |

	Examples: 
	| FromLocation               | ToLocation                  | ErrorMessage                                                                |
	| Sutton Common Rail Station | InvalidLocation 123         | Sorry, we can't find a journey matching your criteria                       |
	| InvalidLocation 1678       | Heathrow Airport Terminal 4 | Sorry, we can't find a journey matching your criteria                       |
	| 23400                      | 34235                       | Journey planner could not find any results to your search. Please try again |

Scenario Outline: Verify that the widget is unable to plan a journey if no locations are entered into the widget 
	Given I click on plan my journey button
	Then I verify the field error messages in Plan my journey page
	| Error          |
	| <ErrorMessage> |

	Examples: 
	| ErrorMessage                |
	| The From field is required. |
	| The To field is required.   |

Scenario: Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	Given I enter the From and To Locations
	| From Location                     | To Location                 |
	| Oxford Circus Underground Station | Heathrow Airport Terminal 4 |
	And I set the Change time in Journey Planner
	| TimeOptions | Day      | Time  |
	| Arriving    | Tomorrow | 10:45 |
	When I click on plan my journey button
	Then I verify the arrival time on journey results

Scenario: Verify that a journey on the Journey results page can be amended by using the “Edit Journey” button
	Given I enter the From and To Locations
	| From Location               | To Location                       |
	| Heathrow Airport Terminal 4 | Oxford Circus Underground Station |
	When I click on plan my journey button
	And I verify the details in journey results
	And I click on edit journey button
	And I edit the journey location details
	| From Location              | To Location                     |
	| Sutton Common Rail Station | Marble Arch Underground Station |
	And I click on update my journey button
	Then I verify the details in journey results

Scenario: Verify that the “Recents” tab on the widget displays a list of recently planned journeys
	Given I enter the From and To Locations
	| From Location               | To Location                       |
	| Heathrow Airport Terminal 4 | Oxford Circus Underground Station |
	When I click on plan my journey button
	And I verify the details in journey results
	And I click on edit journey button
	And I edit the journey location details
	| From Location              | To Location                     |
	| Sutton Common Rail Station | Marble Arch Underground Station |
	And I click on update my journey button
	And I verify the details in journey results
	And I select a travel option
	And I navigate to plan a journey home page
	And I click on the Recent tab
	Then I verify the recent journeys made


