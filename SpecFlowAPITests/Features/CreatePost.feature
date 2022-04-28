Feature: CreatePost

 Create a new Post

@regression
Scenario Outline: Create a new Post
	Given I create a new post using id '<id>' title '<title>' and author '<author>'
	And I deleted the created with id '<id>' title '<title>' and author '<author>'
	Examples: 
	| id | title   | author   |
	| 61 | title61 | author61 |