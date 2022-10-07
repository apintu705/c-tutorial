Feature: BookLibrary
	To manage my books, I want a system that does this for me.

@addBook	
Scenario: Adding a book to the library
	Given I have a book with name "Harry Potter"
	And author is "JKR"
	And price is "100"
	When I add the book the library
	Then my library would look like this
	| Title        | Author | Price |
	| Harry Potter | JKR    | 100   |
	| C# in depth  | XYZ    | 150   |

@addBook
Scenario: Dont add empty book name
	Given I have a book with name ""
	And author is "JKR"
	And price is "100"
	When I add the book the library
	Then I should have an error "Invalid arguments"
	And my library would look like this
	| Title        | Author | Price |
	| C# in depth  | XYZ    | 150   |

@listBook
Scenario: List all books in library
	Given I have a library of books
	When I fetch my books
	Then I should have the following books
	| Title          | Author | Price |
	| Harry Potter   | JKR    | 100   |
	| Harry Potter 2 | JKR    | 200   |
	| C# in depth    | XYZ    | 150   |