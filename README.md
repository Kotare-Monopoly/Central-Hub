# Central-Hub

## POST - http://edacentralhub.azurewebsites.net/api/v1/newgame

Move `currentPlayer` by `dieResult` squares. Subtract hours from `currentPlayer`'s total if the new location has a cost.

```
{
	"dieResult": 9,
	"currentPlayer": 1
}
```

## GET - http://edacentralhub.azurewebsites.net/api/v1/newgame

Reset both player positions to 0, and hours to 1500. (Rather unidiomatic in that a GET changes the DB!)

```
[
	{
		Id: 1,
		Name: null,
		Hours: 1500,
		CurrentPositionId: 0
	},
	{
		Id: 2,
		Name: null,
		Hours: 1500,
		CurrentPositionId: 10
	}
]
```

## GET - http://edacentralhub.azurewebsites.net/api/v1/gamestate

Return current values for both players.

```
[
	{
		Id: 1,
		Name: null,
		Hours: 1380,
		CurrentPositionId: 9
	},
	{
		Id: 2,
		Name: null,
		Hours: 1500,
		CurrentPositionId: 20
	}
]
```
