﻿Feature: AuctionScenarios
	As a potential buyer in an online auction
	I want to be able to bid on an item
	So that I can participate in the auction

@mytag
Scenario: Displaying information about the current item
	Given I am in the auction room
	Then I see the current item picture, description and name
	And I see the current highest bid with a button to place a new bid

Scenario: Single user bidding on an item
	Given I am in the auction room
	Then I place a bid on an item
	And I am the only bidder
	Then I am the highest bidder

Scenario: Multiple users biddeng on an item - you are first
	Given I am in the auction room
	Then I place a bid on an item
	And I am not the only bidder
	And my bid was placed first
	Then I am the highest bidder

Scenario: Multiple users biddeng on an item - you are not first
	Given I am in the auction room
	Then I place a bid on an item
	And I am not the only bidder
	And my bid was not placed first
	Then I am not the highest bidder