﻿/*
 * Created by SharpDevelop.
 * User: calex
 * Date: 15-02-2012
 * Time: 22:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using NSimpleOLAP.Interfaces;
using NSimpleOLAP.Storage.Interfaces;

namespace NSimpleOLAP.Storage.Molap.Graph
{
	/// <summary>
	/// Description of Node.
	/// </summary>
	internal abstract class Node<T, U> : IDisposable
		where T: struct, IComparable
		where U: class, ICell<T>, new()
	{
		public T Key
		{
			get;
			set;
		}
		
		public KeyValuePair<T,T>[] Coords
		{
			get;
			set;
		}
		
		public bool IsRootDim
		{
			get;
			set;
		}
		
		public NodeCollection<T, U> Adjacent
		{
			get;
			protected set;
		}
		
		public U Container
		{
			get;
			protected set;
		}
		
		protected abstract Node<T, U> Create(T childkey, KeyValuePair<T,T>[] coords);
		
		public Node<T, U> GetNode(T[] coords)
		{
			return this.GetNode(coords, 0);
		}
		
		private Node<T, U> GetNode(T[] coords, int index)
		{
			Node<T, U> node = null;
			T key = coords[index];
			
			if (index < coords.Length-1 && this.Adjacent.ContainsKey(key))
				node = this.Adjacent[key].GetNode(coords, index + 1);
			else if (coords.Length-1 == index && this.Adjacent.ContainsKey(key))
				node = this.Adjacent[key];
			
			return node;
		}
		
		internal static KeyValuePair<T,T>[] GetCoords(KeyValuePair<T,T>[] pairs, KeyValuePair<T,T> pair)
		{
			List<KeyValuePair<T,T>> values = new List<KeyValuePair<T, T>>(pairs);
			values.Add(pair);
		
			return values.ToArray();
		}
		
		internal Node<T,U> InsertChildNodeIfNotExists(T childkey, KeyValuePair<T,T>[] coords)
		{
			Node<T,U> nnode = null;
			
			if (this.Adjacent.ContainsKey(childkey))
				nnode = this.Adjacent[childkey];
			else
			{
				nnode = this.Create(childkey, coords);
				this.Adjacent.Add(childkey,nnode);
			}
			
			return nnode;
		}
		
		internal void InsertNode(Node<T,U> childnode)
		{
			if (!this.Adjacent.ContainsKey(childnode.Key))
				this.Adjacent.Add(childnode.Key,childnode);
		}
		
		#region IDisposable implementation
		
		public void Dispose()
		{
			this.Adjacent.Dispose();
		}
		
		#endregion
	}
}