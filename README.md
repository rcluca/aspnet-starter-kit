# Setup

To get the application running, you'll need some prerequistes, which can be found in the documentation of the [AspNet Starter Kit](https://github.com/kriasoft/aspnet-starter-kit#prerequisites) I used.

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

# Outstanding Issues/Work to be Done
While I was able to implement a large part of the requirements, I did not have enough time to complete the file uploading/editing.  Additionally, some bugs remain.

## File Uploading/Editing
### UI
I would have a table of uploaded files below Appointments on the Patient Profile page.  It would display the file name, date uploaded, size, and type.

An add link would exist like for "Scheduling an Appointment", except that chen clicked, a modal would pop-up, with the option to search for a file and upload it.

Physicians would have the ability to remove files using a button on the right side of the table.  When clicked, a modal would pop-up, asking the Physician to confirm.

### Server
The files would probably be stored in the database as blobs, but if the file sizes are typically really large, it might be better to store them in the file system and only store a reference to them in the database.

## Bugs
### Get Profile by Physician
Currently, I've hard-coded in the PatientController Patient 2, Cleopatra, whenever a Physician clicks on a Patient in the list of Patients.  A bug with the default routing that came with the startup project I'm using isn't translating the Id query parameter properly.  I didn't have time to write a work-around.

### Dates
Not really a bug, but more consideration needs to be put into how the dates are stored in order to account for different time zones, both for the user and the server.  Currenlty, I'm saving local time of the user and server, but these could be out of sync if the location of either changes, which is very likely in a production environment.