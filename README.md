# Automatic Traffic Light Controller Application with AI Image Sensoring

## Table of Contents

- [Overview](#overview)
- [Project Proposal](#project-proposal)
- [Technology Stack](#technology-stack)
- [Features](#features)
- [Architecture](#architecture)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [License](#license)

## Overview

This project implements a traffic signal control application using the .NET platform in Visual Studio Code with C#. The application controls traffic signals based on real-time data from cameras or sensors, aiming to optimize traffic flow and accommodate pedestrian crossings. 

## Project Proposal
An application that controls traffic signals based on the traffic from each direction, i.e., if the traffic from a direction is zero - no vehicles, then the traffic light will be green for the other directions unless a vehicle comes in the former path or a pedestrian pressed to cross the road. The input for the application will be the data collected by cameras or sensors on the road with True as when there is a vehicle and False as when there is no vehicle.

## Technology Stack
- C# with .NET SDK
- Visual Studio Code
- SQL Server from Docker Container for Database Management with Azure Data Studio as Client
- GPIO library (for actual hardware integration)

## Features

- Real-time traffic light control based on sensor data
- Sensor integration using GPIO (General Purpose Input/Output)
- Database connectivity for storing and retrieving sensor data
- Mock GPIO controller for development and testing on non-Linux platforms

## Architecture

The application is built on the .NET platform using C# and follows a modular architecture:
- **IGpioController Interface:** Abstracts GPIO operations.
- **RealGpioController:** Implements GPIO operations using the `System.Device.Gpio` library.
- **MockGpioController:** Provides mock implementations for GPIO operations for non-Linux platforms.
- **TrafficControlService:** Contains the logic for controlling traffic lights.
- **Program.cs:** Executes the application.


## Data and General Purpose Input/Output Pins (GPIO)

In a practical approach, the data required for this application to run properly is a boolean input - `True` or `False`. A sensor or an image processing AI model provides the information about the presence of vehicles along a direction. 

The value will be `True` for a specific traffic when -  
- There is a vehicle detected in that traffic
- (or) A pedestrian requests for crossing in the opposite traffic

And `False` when there is no vehicle in the specific traffic

<figure>
<img src ="img/traffic_graphic.png" alt="AI generated traffic intersection image" width="50%;">
<figcaption>Figure: AI generated traffic intersection image using Microsoft Designer (https://designer.microsoft.com/image-creator) tool </figcaption>
</figure>

## Setup and Installation

### Cloning the Repository

```bash
git clone https://github.com/RindhujaTreesa/ai-sensored-automatic-traffic-light-controller-application.git
cd ai-sensored-automatic-traffic-light-controller-application
```

### Setting Up the Database

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourPassword123' -p 1433:1433 --name sql_server -d mcr.microsoft.com/mssql/server
```

### Create the Database and Table

``` sql
CREATE DATABASE TrafficControlDB;
USE TrafficControlDB;

CREATE TABLE TrafficSensorData (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IsVehiclePresent BIT NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE()
);
```

### Insert sample data

```sql
INSERT INTO TrafficSensorData (IsVehiclePresent)
VALUES
(0), (0), (0), (1), (1), (1), (1), (1), (1), (0), (0), (0);
```

### Configure the Program.cs file with the Database

```c#
string connectionString = "Server=localhost,1433;Database=TrafficLightControl;User Id=sa;Password=YourPassword123;";
```
In the project, the database connection credentials are avoided from being pushing into Git using .gitignore
## Usage

To use the application, ensure the database is set up correctly and the connection string in Program.cs is updated. Run the application using dotnet run and observe the console output for traffic control decisions.

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit). See the [LICENSE](/LICENSE) file for details.

