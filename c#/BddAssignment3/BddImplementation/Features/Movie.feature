Feature: AddMovieFeature
In order to add movie details to the list
as per input entered by user
I want to all the movie  in the list of movies

Scenario: Add Movie
	Given I have an application which stores movies with it's details 
	And I entered MovieName as 'bahubali'
	And I entered MoviePlot as 'action'
	And I entered ReleaseDate as '11/12/2000'
	And I entered Actors as 'salman'
	And I entered Producer as 'Disney'
	When I entered all the details correctly i should add the movie to the list 
	Then I get a confirmation message as 'successfully added'



	@GetMovieList
Scenario: Get Movie List
	Given I have an application which stores movies with it's details
	When I asked for movies 
	Then I should get these movies
	| Id | MovieName | MoviePlot | ReleaseDate | Actors | Producer |
	| 1  | bahubali  | action   | 11/12/2000  | salman | Disney   |

Scenario: Add Movie invalid arguments
	Given I have an application which stores movies with it's details 
	And I entered MovieName as ''
	And I entered MoviePlot as 'action'
	And I entered ReleaseDate as '11/12/2000'
	And I entered Actors as 'salman'
	And I entered Producer as 'Disney'
	When I entered all the details correctly i should add the movie to the list 
	Then I get a error message as 'Invalid arguments'
