Feature: Booking.com listings for Limerick
	Tests to validate new filter options

Background:

Scenario Outline: Booking
	Given Booking.com homepage is loaded
	And I Search for a room for 2 in 'Limerick' for 1 night 90 days from today
	When I filter by '<FILTER>'
	Then Assert '<HOTEL>' is '<LISTED>'

	Examples:
		| FILTER | HOTEL                 | LISTED |
		| Sauna  | Limerick Strand Hotel | True   |
		| Sauna  | George Limerick Hotel | False  |
		| 5 Star | The Savoy Hotel       | True   |
		| 5 Star | George Limerick Hotel | False  |