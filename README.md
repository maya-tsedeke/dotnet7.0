# dotnet7.0
These are the general steps you can follow to create a .NET Web API with a React frontend. There are various tools and libraries available that can make the process easier and more efficient, depending on your specific needs and preferences.

Here are the steps to create a .NET Web API with a React frontend using Visual Studio Code:

Install the necessary tools: Install Visual Studio Code, .NET Core SDK, and Node.js on your machine.

Create a new .NET Web API project: Open Visual Studio Code and create a new folder for your project. Open the terminal in Visual Studio Code and navigate to the project folder. Run the command dotnet new webapi to create a new .NET Web API project.
1. Open a new terminal window in Visual Studio Code and navigate to the folder you just created. Then create the folowing empty subfolders for Clean architecture dotnet7 projects

        mkdir webapi
        mkdir Domain
        mkdir Application
        mkdir Infrastructure
        mkdir Client 

2. Navigate to the each sub folders that you crrated and create the dotnet projects inside the subproject project inside

        dotnet new sln  
        cd webapi
        dotnet new webapi --no-https
        cd ..
        dotnet new classlib -o Domain
        dotnet new classlib -o Application
        dotnet new classlib -o Infrastructure
3. Add to your web Api projects to your solution that you created in the first line 

        dotnet sln add webapi/webapi.csproj 
        dotnet sln add Domin/Domain.csproj 
        dotnet sln add Application/Application.csproj 
        dotnet sln add Infrastructure/Infrastructure.csproj 

4. Add project references in your Web API projects to your domain, application, and infrastructure projects. This can be done by adding the following lines to the .csproj file of your Web API project:

        dotnet add webapi/api.csproj reference Infrastructure/Infrastructure.csproj
        dotnet add webapi/api.csproj reference Applications/Applications.csproj
        dotnet add Applications/Applications.csproj reference Domain/Domain.csproj
        dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj


Run the Web API project: Run the command dotnet run to start the Web API project. The project will run on http://localhost:5000.

Create a new React app: Open a new terminal window and navigate to the project folder. Run the command npx create-react-app client to create a new React app.

Install dependencies: Install the necessary dependencies for the React app. In the terminal window, navigate to the client folder and run the command npm install axios react-router-dom.

Create a proxy for the React app: Create a proxy property in the package.json file of the React app. Set the value to "proxy": "http://localhost:5000". This will allow the React app to make HTTP requests to the Web API.

Modify the React app: Modify the App.js file of the React app to make HTTP requests to the Web API. You can use the Axios library to make HTTP requests. For example, you can add a componentDidMount method to make a GET request to the Web API:

        import React, { Component } from 'react';
        import axios from 'axios';

        class App extends Component {
        state = {
            data: []
        }

        componentDidMount() {
            axios.get('/api/values')
            .then(response => {
                this.setState({ data: response.data });
            });
        }

        render() {
            return (
            <div>
                {this.state.data.map(item => (
                <p key={item}>{item}</p>
                ))}
            </div>
            );
        }
        }

        export default App;
This code makes a GET request to the /api/values endpoint of the Web API and updates the state of the component with the response data.

Run the React app: Open a new terminal window and navigate to the client folder. Run the command npm start to start the React app. The app will run on http://localhost:3000.

Test the application: Open a web browser and navigate to http://localhost:3000. You should see the React app running and making requests to the Web API. Verify that the data is being displayed correctly.

These are the general steps to create a .NET Web API with a React frontend using Visual Studio Code. There are various tools and libraries available that can make the process easier and more efficient, depending on your specific needs and preferences.