﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DriveToSurvive
{
    public class Car
    {
        public int z, speed, steer, trackLocation, distToTrack, placeNumber = 0;
        public double xSpeed, ySpeed, direction, x, y, prevXSpeed, prevYSpeed = 0;
        public int width = 30;
        public int height = 50;

        public Car(double _x, double _y, double _dirction)
        {
            x = _x;
            y = _y;
            direction = _dirction;
        }

        public void Move()
        {
            direction += steer * speed / 75;

            if (direction >= 360)
            {
                direction -= 360;
            }
            if (direction < 0)
            {
                direction += 360;
            }
            prevXSpeed = xSpeed * 10;
            prevYSpeed = ySpeed * 10;
            SetSpeed(direction);
            direction = Form1.GetDirection(xSpeed, ySpeed);

            x += (xSpeed * speed) / 20;
            y -= (ySpeed * speed) / 20;

            distToTrack = 0;
            for (int i = 0; i < GameScreen.trackpoints.Count; i++)
            {
                if (Math.Sqrt((GameScreen.trackpoints[i].x - x) * (GameScreen.trackpoints[i].x - x) + (GameScreen.trackpoints[i].y - y) * (GameScreen.trackpoints[i].y - y)) < distToTrack || distToTrack == 0)
                {
                    distToTrack = (int)Math.Sqrt((GameScreen.trackpoints[i].x - x) * (GameScreen.trackpoints[i].x - x) + (GameScreen.trackpoints[i].y - y) * (GameScreen.trackpoints[i].y - y));

                    if (distToTrack == 0)
                    {
                        distToTrack = 1;
                    }
                    trackLocation = i;
                }
            }
        }

        public void SetSpeed()
        {
            double direction = Form1.GetDirection(xSpeed, ySpeed);
            xSpeed = Math.Sin(direction * Math.PI / 180);
            ySpeed = Math.Cos(direction * Math.PI / 180);
        }

        public void SetSpeed(double direction)
        {
            xSpeed = Math.Sin(direction * Math.PI / 180);
            ySpeed = Math.Cos(direction * Math.PI / 180);
        }
    }
}
