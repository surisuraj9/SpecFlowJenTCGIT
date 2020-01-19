Feature: feature to login

Scenario: user tries to login in to page scenario
	Given user opens browser with url
	Then user enters "surajp" as "username" and "suraj1234" as "password" in "login" page
	Then user clicks on "login_button" in "login" page
	Then user validates "userNameLabel" as "  User: padmanabhuni suraj" in "home" page
	Then user validates "title" as "CRMPRO" in "home" page
	