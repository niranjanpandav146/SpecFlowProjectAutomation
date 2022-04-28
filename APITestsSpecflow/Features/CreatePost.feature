Feature: CreatePost

 Create a new Post


@regression
Scenario Outline: Create a new Post
	Given I create a new post using id '<id>' title '<title>' and author '<author>'
	Then I should be able to get the post with id '<id>' title '<title>' and author '<author>'
	
	Examples: 
	| id | title   | author   |
	| 61 | title61 | author61 |