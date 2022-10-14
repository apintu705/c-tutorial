Feature: MovieApp
	To manage my MovieApp, I want a system that add movie to the list and get all the movies form list.


	
	@addMovie
Scenario: Adding a Movie to the MovieApp
	Given I have to add a movie with the details as "<movieName>", "<moviePlot>", "<YearOfRelease>", "<Actors>" and "<Producer>"
	When I add the movie to the MovieApp
	Then display message "<message>" on the screen
	@invalidData
	Examples: 
	| movieName | moviePlot | YearOfRelease | Actors | Producer | message                   |
	|           | fantasy   | 2010          | 1 2    | 1        | failed Invalid inputs     |
	| Avatar    | fantasy   | 2010          |        | 1        | failed Invalid inputs     |
	| Avatar    | fantasy   |               | 1 2    | 1        | failed Invalid inputs     |
	| Avatar    |           | 2010          | 1 2    | 1        | failed Invalid inputs     |
	| Avatar    | fantasy   | 2010          | 1 2    |          | failed Invalid inputs     |
	@validData
	Examples:
	| movieName | moviePlot | YearOfRelease | Actors | Producer | message                   |
	| Avatar    | fantasy   | 2010          | 1 3    | 1        | successfully added        |
	

	@listMovies
Scenario: List all movies in MovieApp
	Given I have a MovieApp of movies
	When I fetch all the movies with details
	Then I should have the following movies
	| Name		| Plot		| YearOfRelease | Actors            | Producers   |
	| Avatar    | fantasy   | 2010          | Will Smith,Alisha | Disney      |
	| Liger     | action    | 2020          | Vijay D,Ananya P  | Dharma      |
	| Tiger     | romance   | 2000          | Salman,Katrina    | Sanjay Dutt |