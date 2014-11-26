using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Map
    {
        static int maxLocation = 3;
        Location[] locations = new Location[maxLocation];
        int currentLocation = 0;

        public Map()
        {
            for (int i = 0; i<maxLocation; i++ )
            {
                locations[i] = new Location();
            }
        }

        public void moveForward()
        {
            currentLocation++;
            if (currentLocation == maxLocation)
            {
                currentLocation = 0;
            }
        }

        public void moveBackward()
        {
            currentLocation--;
            if (currentLocation < 0)
            {
                currentLocation = maxLocation - 1;
            }
        }

        public int getPop()
        {
            return locations[currentLocation].getPop();
        }

        public int getBandits()
        {
            return locations[currentLocation].getBandits();
        }

        public int getLocation()
        {
            return currentLocation;
        }
    }

    class Location
    {
        int population;
        int bandits;

        static int locationNum = 0;

        public int getPop()
        {
            return population;
        }

        public int getBandits()
        {
            return bandits;
        }

        public Location()
        {
            locationNum++;
            switch (locationNum % 3)
            {
                case 0:
                    {
                        population = 15;
                        bandits = 0;
                        break;
                    }
                case 1:
                    {
                        population = 300;
                        bandits = 0;
                        break;
                    }
                case 2:
                    {
                        population = 0;
                        bandits = 3;
                        break;
                    }
            }
        }
    }
}
