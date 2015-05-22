# Central-Hub

## POST - http://edacentralhub.azurewebsites.net/api/v1/newgame

```
{
	"dieResult": 9,
	"currentPlayer": 1
}
```

## GET - http://edacentralhub.azurewebsites.net/api/v1/newgame

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
