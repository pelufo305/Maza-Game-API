# MAZE API

This API is developed to create, execute and move in a maze by means of commands. Informing if you have reached the limit of the game board.


## Technologies used
* Net 6

## Architectural patterns
* DDD
* CQRS
* Layers

## Patterns Design
* Singleton
* Mediator
* SOLID

## Data persistence
* **Memory Database**
* **Singleton List:** A singleton list is created which saves the board, the movements in order to be able to validate them in the same context of the API execution.




## EXAMPLE OF GAME SESSION

## Operations in the maze

* **GoNorth**
* **GoSouth**
* **GoEast**
* **GoWest**
* **Start**

## 1. Create a new random maze
#### [POST] https://localhost:7208/api/Maze

```
[BODY] 
{
  "width": 50,
  "height":50
}
```
```
[RESPONSE]
{
  "mazeUid": "c30d88c7-7ebf-4aec-812c-ce487028378e",
  "height": 50,
  "width": 50
}
```

## 2. Create a new game using the new maze
#### [POST]  "https://localhost:7208/api/Game/{mazeUid}
#### [Example]  "https://localhost:7208/api/Game/c30d88c7-7ebf-4aec-812c-ce487028378e"

```
[BODY] 
{
  "operation": "Start"
}
```
```
[RESPONSE]
{
  "mazeUid": "c30d88c7-7ebf-4aec-812c-ce487028378e",
  "gameUid": "79329364-a202-407b-b7d7-77380bb2bb7e",
  "completed": false,
  "currentPositionX": 20,
  "currentPositionY": 33
}
```

## 3. Move next cell
#### [POST]  https://localhost:7208/api/Game/{mazeUid}/{gameUid}
#### [Example] https://localhost:7208/api/Game/c30d88c7-7ebf-4aec-812c-ce487028378e/79329364-a202-407b-b7d7-77380bb2bb7e

```
[BODY] 
{
  "operation": "GoWest"
}
```
```
[RESPONSE]
{
  "game": {
    "mazeUid": "c30d88c7-7ebf-4aec-812c-ce487028378e",
    "gameUid": "79329364-a202-407b-b7d7-77380bb2bb7e",
    "completed": false,
    "currentPositionX": 0,
    "currentPositionY": 0
  },
  "mazeBlockView": {
    "coordX": 20,
    "coordY": 32,
    "northBlocked": true,
    "southBlocked": true,
    "westBlocked": false,
    "eastBlocked": false
  }
}
```



## 5. Verify Game
#### [GET]  https://localhost:7208/api/Game/{mazeUid}/{gameUid}
#### [Example] https://localhost:7208/api/Game/e679b8a8-ea19-447d-a40a-0b6d40e6e9b8/efd8b8e8-779d-499a-8610-2adb71ee9b56

```
{
  "mazeUid": "e679b8a8-ea19-447d-a40a-0b6d40e6e9b8",
  "gameUid": "efd8b8e8-779d-499a-8610-2adb71ee9b56",
  "width": 50,
  "height": 50,
  "blocks": [
    {
      "coordX": 43,
      "coordY": 13,
      "northBlocked": false,
      "southBlocked": true,
      "westBlocked": true,
      "eastBlocked": false
    },
    {
      "coordX": 43,
      "coordY": 13,
      "northBlocked": false,
      "southBlocked": true,
      "westBlocked": true,
      "eastBlocked": false
    },
    {
      "coordX": 43,
      "coordY": 14,
      "northBlocked": false,
      "southBlocked": true,
      "westBlocked": false,
      "eastBlocked": false
    },
    {
      "coordX": 43,
      "coordY": 14,
      "northBlocked": false,
      "southBlocked": true,
      "westBlocked": false,
      "eastBlocked": false
    }
  ]
}
```


## 5. History Maze
#### [GET]  https://localhost:7208/api/Game/{mazeUid}
#### [Example] https://localhost:7208/api/Game/c30d88c7-7ebf-4aec-812c-ce487028378e

```
{
  "mazeUid": "c30d88c7-7ebf-4aec-812c-ce487028378e",
  "width": 50,
  "height": 50,
  "blocks": [
    {
      "coordX": 20,
      "coordY": 33,
      "northBlocked": true,
      "southBlocked": true,
      "westBlocked": false,
      "eastBlocked": true
    },
    {
      "coordX": 20,
      "coordY": 32,
      "northBlocked": true,
      "southBlocked": true,
      "westBlocked": false,
      "eastBlocked": false
    },
    {
      "coordX": 20,
      "coordY": 32,
      "northBlocked": true,
      "southBlocked": true,
      "westBlocked": false,
      "eastBlocked": false
    }
  ]
}
```


## Author

Jhonatan Stiven Gonzalez Pelufo
