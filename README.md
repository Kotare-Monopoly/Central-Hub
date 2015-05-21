# Central-Hub

## Route - DiceRoll

api/GameState/DiceRoll


## Route - Request Game Info

api/GameState/GameInfo


## JSON Spec (Example Below) - New Turn

```
  [
	{
		listofLocations : {
			id : locationName
		}
	
		player1 : {
			hours : amount (int),
			newLocation :  int
			locationDetails : string	
		}

		player2 : {
			hours : amount (int),
			newLocation : int,
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
			hours : 1500,
			newLocation : 5,
			locationDetails : "Pay player2 rent of $50"
		},
		
		player2 : {
			hours : 1550,
			newLocation : 9,
			locationDetails : "No one owns this property."
		}
	}
]
```
