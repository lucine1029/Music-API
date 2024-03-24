This is my biggest group project where we developed a web API and a client application. By using REST architecture, EntityFramework and ASP.NET, we constructed the API which could allow external services and applications to retrieve and modify data in our own application.  

## Endpoints with their assigned payloads

### GET endpoints ###

  - /user/{userId}/track  **-Gets all tracks connected to a single user**

  - /user/{userId}/genre  **-Gets all genres connected to a single user**

  - /user/{userId}/artist  **-Gets all artists connected to a specific user**

  - /user/{userId}/track  **-Gets all tracks connected to a specific user**

    

    
### Post endpoints ###

- /track  **-Add new track:**
    
*Payload:*
  
```json
{  
    "TrackTitle": "Track title", 
    "Genre": "Genre",  
    "Artist": "Artist" 
}
```
- /user  **Adds new user**

*Payload:*

```json
{  
	"UserName": "User name"
}
```
- /genre  **Adds new genre**

*Payload:*

```json
{  
	"GenreName":"Genre"
}
``` 

- /user/{userId}/genre/{genreId}  **Connects user to a genre**

- /user/{userId}/artist/{artistId}  **Connets user to a artist**

- /user/{userId}/track/{trackId}  **Connects user to a track**

![My Diagram](SpelarDuInAPIDiagram.drawio.svg)
