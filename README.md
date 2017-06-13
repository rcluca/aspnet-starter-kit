# Setup

I used the [AspNet Starter Kit](https://github.com/kriasoft/aspnet-starter-kit) as the base for my application as it comes ready with React, Redux, Webpack, and client side routing (needed for a SPA).

### Prerequisites
- Windows
- [Node.js](https://nodejs.org/en/) v6 or newer
- [.NET Core](https://www.microsoft.com/net/core#windowsvs2017)

Currently this app can only run on Windows because it connects to a Sql Server database locally.  Alternatively, it could be run on OSX or Linux given that the connection strings in the appSettings.config files are changed to point to a running Sql Server database on a Windows machine or in a Docker like container.

### Running the Application
Now, open up a terminal or command prompt, `cd` into the root directory of the project and run the following:

`$ npm install`

`$ node run`

This should build the application, install all of it's dependencies, create and seed the database, and start the application in a browser.  You can now login with a user and use the app.

# Available Users
## Patients

### Caesar
- Username: `caesar@rome.com`
- Password: `Veni_Vidi_Vici0`

### Cleopatra
- Username: `cleopatra@egypt.com`
- Password: `Iwillnotbetriumphedover_0`

## Physicians

### Hippocrates
- Username: `hippocrates@oath.com`
- Password: `DoNoHarm_0`

### Herophilos
- Username: `herophilos@anatomy.com`
- Password: `SnakeOilIsGood_0`

# Outstanding Issues
## Known Bugs
### Get Patient Profile by Physician
Currently, I've hard-coded in the PatientController Patient 2, Cleopatra, so that whenever a Physician clicks on a Patient in the list of Patients, she's the only patient they ever see.  A bug with the default routing that came with the startup project I'm using isn't translating the Id query parameter properly.  I didn't have time to implement a work-around.

### Scheduling Appointments in the Past
No business logic has been implemented to disallow users from scheduling appointments in the past but this would be a great addition.

## Miscellaneous
### Dates
More consideration needs to be put into how the dates are stored in order to account for different time zones, both for the user and the server.  Currenlty, I'm saving local time of the user and server, but these could be out of sync if the location of either changes, which is very likely in a production environment.

### Filtering
Filtering currently only works on Blur, which may not be intuitive.  I would either add a button or implement filtering on Change with the appropriate throttling.  Additionally, filtering is currently being done in the UI but as the data set grows, this would need to be transitioned to the server and some king of paging would need to be implemented.

# Work to be Done
While I was able to implement a large part of the requirements, I did not have enough time to complete the file uploading/editing.

## File Uploading/Editing
### UI
I would have a table of uploaded files below Appointments on the Patient Profile page.  It would display the file name, date uploaded, size, and type.

An add button would exist, that when clicked, a modal would pop-up, with the option to search for a file (perhaps using the built-in HTML file type input) and upload it.

Physicians would have the ability to remove files using a button on the right side of the table.  When clicked, a modal would pop-up, asking the Physician to confirm.

### Server
The files would probably be stored in the database as blobs, but if the file sizes are typically really large, it might be better to store them in the file system and only store a reference to them in the database (though more recent versions of databases, particularily Sql Server, have optimized implementations that combine the two but without the manual headache of managing references to the filesystem).

# Final Touches
## Server
### Tests
Back-end tests need to be written.  I would write them at the API level instead of the class/method level because of the enormous benefits to refactoring gained by having a stable API.  Additionally, API unit tests can be easily changed to integration tests by not mocking the database.  **I welcome discussion on this topic as I've spent significant time in this area**.

In terms of front-end tests, I would write few to none.  Through experience, I've found that the UI changes so frequently that these tests are always changing.  It's also rather hard to write these tests, typically taking longer than implementing the functionality, and quite easy to manually QA changes through the browser.  Lastly, but not leastly, with React being so modular, changes in one part of the UI code rarely effect any other part, so risk of breaking behavior is minimal.

### Server Error Messages
I threw exceptions when the input didn't pass business validation on the server.  This is not great because the UI only receives a 500 status code, which is uninformative.  I would refactor this to return a more appropriate HTTP status code and a list of errors so the UI can display them to the user or otherwise action them appropriately.

### Authentication/Session Management
I've integrated the authentication and session management into the application but in real life, where a company has many applications, this is not ideal for the users or the IT department who is managing permissions.  I would refactor this into one or two separate services (Authentication and Sessions services) so that all applications can use them.  Further, there might be a distinction between external and internal applications, so this could lead to two instances or implementations of the services.

### Microservices
My company has made a huge push toward microservices in the last year, with successes and failures.  I'm not quite sure yet the best way to "do" microservices, and I know many people have the same problem, but I have found benefits in breaking things apart somewhat.  In the context of this application, I would probably breaking things along domain contexts, like Patients, Physicians, and Appointments.  **I welcome discussion on approaching scaling and complexity**.

### Logging
I added logging somewhat sporadically as I needed it to debug but for a production ready application, I would be more strategic about this.  **I welcome discussion on how to determine what should be logged and how**.

## UI
### UI Modularization
I didn't spend too much time on breaking apart my UI views into separate components but this would be beneficial to better separate concerns (SOLID principles).  For example, I would split out the Approve and Cancel buttons and their functionality from the Profile page.  **I welcome discussion on the how and why of separating components**.

### UI/UX Design
I used React Bootstrap but other than that, I mostly put this on the backburner to get the functional requirements completed.  However, I would spend more time cleaning things up and thinking about where things should be positioned and what copy should be displayed, etc.  Full admission as well, I'm not very good at UI/UX design, so I would definitely partner with someone with those skills.

### ESLint
The base project I used had this hooked up but for some reason I was never able to get it working (didn't spend much time on it though).  I would love to have set this up and use it because it's really good at catching bugs like misspellings and undeclared variables as well as great for keeping teams formatting their code the same throughout.
