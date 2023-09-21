# Taipei 101 Simulator
I designed a dynamic simulation to illustrate the impact and movement of a Mass Damper within a skyscraper. This simulation offers users a visual understanding of how these engineering marvels work to stabilize tall buildings.

![image](https://github.com/kOmplex01/taipei101/assets/98254989/f013c102-0ed1-4716-82c1-1724b1a2a78d)

The simulation doesn't just rely on static visuals; it leverages real-time physics to replicate the actual motion of a skyscraper, including swaying influenced by external forces like wind. It also vividly demonstrates the consequences of damper failure, highlighting their critical role in structural stability.

## Features Defined
To enhance user engagement and interactivity, we integrated custom sliders into the simulation. These sliders allow users to adjust key parameters in real-time. This hands-on approach enables users to experiment with different damper configurations, making the learning experience both educational and enjoyable.

### Damper Stats
Based on the disaster stats generated, the damper stats are to be changed by the user playing the simulator.
```
Mass -> To change the mass of the Damper
Rope Length -> To change the length of the supporting ropes connected to the Damper
Rope Stiffness -> TO change the stiffness of the Hydraulic Pistons connected to the Damper
```
### Disaster Stats
The disaster stats are randomly generated towards each level, in which every variable is clamped in between a range to provide practical simulation.
```
Time -> Decides the time after which the Natural Disaster will end.
```
#### Earthquake
It is responsible for the displacement of the building based on the **Rickter Scale** and **Distance** variables, with major movement in horizontal plane and little movement in the vertical axis.
```
Richter Scale -> Magnitude of the Earthquake generated
Distance -> Distance between the Epicentre of the Earthquake and the Building
```
#### Typhoon
It is responsible for the rotation of the building around the lowest point of the building based on the **Wind Velocity** variable.
```
Wind Velocity -> Velocity of the winds during the Typhoon
```
Try to tweak the values to observe the changes

## About the Scene
This project is highly accurate as all the calculations are done in the runtime, and the damper can move in any direction.
The camera is scripted to rotate around the damper with zoom functionality to observe every angle of the simulation and study the movement of the damper.
Touch Input can access the UI on a PC or by VR Headsets.



https://github.com/kOmplex01/taipei101/assets/98254989/884596db-c78e-4065-a24d-1803eec58e71


