# Central-Hub

## POST Route - DiceRoll

api/GameState/DiceRoll


## GET Route - Request Game Info

api/GameState/GameInfo


## JSON Spec (Example Below) - New Turn

```
  [
	{
		listofLocations : {
			id : locationName
		}
	
		player1 : {
			playerId : 1,
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
			playerId : 1,
			hours : 1500,
			newLocation : 5,
			locationDetails : "Pay player2 rent of $50"
		},
		
		player2 : {
			playerId : 2,
			hours : 1550,
			newLocation : 9,
			locationDetails : "No one owns this property."
		}
	}
]
```
