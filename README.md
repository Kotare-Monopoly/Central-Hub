# Central-Hub

## JSON Spec (Example Below) - New Turn

```
  [
	{
		listofLocations : {
			id : locationName
		}
	
		player1 : {
			money : amount (int),
			newLocation :  string
			locationDetails : string	
		}

		player2 : {
			money : amount (int),
			newLocation : string,
			locationDetails : string
		}
	}	
]
```
## JSON Example - New Turn

```
[
	{
		listOfLocations : {
			1 : "Go",
			2 : "First Brown Street",
			...,
			40 : "Mayfair"
		},
		
		player1 : {
			money : 1500,
			newLocation : "Mayfair",
			locationDetails : "Pay player2 rent of $50"
		},
		
		player2 : {
			money : 1550,
			newLocation : "Leicester Square",
			locationDetails : "No one owns this property."
		}
	}
]
```
