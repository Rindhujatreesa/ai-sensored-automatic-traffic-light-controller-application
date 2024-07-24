# Automatic Traffic Light Controller Application with AI Image Sensoring

## Project Proposal
An application that controls traffic signals based on the traffic from each direction, i.e., if the traffic from a direction is zero - no vehicles, then the traffic light will be green for the other directions unless a vehicle comes in the former path or a pedestrian pressed to cross the road. The input for the application will be the data collected by cameras or sensors on the road with True as when there is a vehicle and False as when there is no vehicle.

## Technology Stack
- C# with .NET platform
- Visual Studio Code
- SQL Server for Database Management

## Data and General Purpose Input/Output Pins (GPIO)

In a practical approach, the data required for this application to run properly is a boolean input - `True` or `False`. A sensor or an image processing AI model provides the information about the presence of vehicles along a direction. 

The value will be `True` for a specific traffic when -  
- There is a vehicle detected in that traffic
- (or) A pedestrian requests for crossing in the opposite traffic

And `False` when there is no vehicle in the specific traffic

![AI Generated Traffic Intersection]("img/traffic_graphics.png")
