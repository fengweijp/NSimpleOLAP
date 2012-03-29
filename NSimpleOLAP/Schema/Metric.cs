﻿using System;
using NSimpleOLAP.Schema.Interfaces;
using NSimpleOLAP.Configuration;

namespace NSimpleOLAP.Schema
{
	/// <summary>
	/// Description of Metric.
	/// </summary>
	public class Metric<T> : IMetric<T>
		where T: struct, IComparable
	{
		public Metric()
		{
		}
		
		public Metric(MetricConfig config)
		{
			this.Config = config;
		}
		
		public object Expression {
			get;
			set;
		}
		
		public string Name {
			get;
			set;
		}
		
		public T ID {
			get;
			set;
		}
		
		public MetricConfig Config { 
			get; 
			set; 
		}
	}
}
