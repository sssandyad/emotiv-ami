﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawDataTestApp
{
    public delegate void RawDataChangedEventHandler(double[] values);

    public interface IRawDataReader
    {
        event RawDataChangedEventHandler Values;

        void Update();

		/// <summary>
		/// Adjust channel for visualization
		/// </summary>
		/// <param name="number"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		double AdjustChannel(int number,double value);

        string ChannelName(int number);
    }
}