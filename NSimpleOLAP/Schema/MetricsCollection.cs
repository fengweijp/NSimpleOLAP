﻿using System;
using System.Collections.Generic;
using NSimpleOLAP.Common;
using NSimpleOLAP.Schema.Interfaces;
using NSimpleOLAP.Storage.Interfaces;

namespace NSimpleOLAP.Schema
{
	/// <summary>
	/// Description of MetricsCollection.
	/// </summary>
	public class MetricsCollection<T> : BaseDataMemberCollection<T, Metric<T>>
		where T: struct, IComparable
	{
		public MetricsCollection(IMemberStorage<T, Metric<T>> storage)
		{
			_storage = storage;
			base.Init();
		}
	}
}
