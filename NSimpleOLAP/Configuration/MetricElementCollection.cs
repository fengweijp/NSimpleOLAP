﻿using System;
using System.Configuration;


namespace NSimpleOLAP.Configuration
{
	/// <summary>
	/// A collection of MetricElement(s).
	/// </summary>
	public sealed class MetricElementCollection : ConfigurationElementCollection
	{
		#region Properties

		/// <summary>
		/// Gets the CollectionType of the ConfigurationElementCollection.
		/// </summary>
		public override ConfigurationElementCollectionType CollectionType
		{
			get { return ConfigurationElementCollectionType.BasicMap; }
		}
	   

		/// <summary>
		/// Gets the Name of Elements of the collection.
		/// </summary>
		protected override string ElementName
		{
		get { return "Metric"; }
		}
			   
	   
		/// <summary>
		/// Retrieve and item in the collection by index.
		/// </summary>
		public MetricElement this[int index]
		{
			get   { return (MetricElement)BaseGet(index); }
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}


		#endregion

		/// <summary>
		/// Adds a MetricElement to the configuration file.
		/// </summary>
		/// <param name="element">The MetricElement to add.</param>
		public void Add(MetricElement element)
		{
			BaseAdd(element);
		}
	   
	   
		/// <summary>
		/// Creates a new MetricElement.
		/// </summary>
		/// <returns>A new <c>MetricElement</c></returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new MetricElement();
		}

	   
	   
		/// <summary>
		/// Gets the key of an element based on it's Id.
		/// </summary>
		/// <param name="element">Element to get the key of.</param>
		/// <returns>The key of <c>element</c>.</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((MetricElement)element).Name;
		}
	   
	   
		/// <summary>
		/// Removes a MetricElement with the given name.
		/// </summary>
		/// <param name="name">The name of the MetricElement to remove.</param>
		public void Remove (string name) {
			base.BaseRemove(name);
		}

	}
}
