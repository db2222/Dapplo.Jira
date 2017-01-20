﻿//  Dapplo - building blocks for desktop applications
//  Copyright (C) 2016 Dapplo
// 
//  For more information see: http://dapplo.net/
//  Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
//  This file is part of Dapplo.Jira
// 
//  Dapplo.Jira is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Dapplo.Jira is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have a copy of the GNU Lesser General Public License
//  along with Dapplo.Jira. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

#region using

using System;
using System.Runtime.Serialization;

#endregion

namespace Dapplo.Jira.Entities
{
	/// <summary>
	///     Comment information
	///     See: https://docs.atlassian.com/jira/REST/latest/#api/2/attachment
	/// </summary>
	[DataContract]
	public class Comment : BaseProperties<long>
	{
		/// <summary>
		///     Who created the comment
		/// </summary>
		[DataMember(Name = "author")]
		public User Author { get; set; }

		/// <summary>
		///     The text of the comment
		/// </summary>
		[DataMember(Name = "body")]
		public string Body { get; set; }

		/// <summary>
		///     When was the comment created
		/// </summary>
		[DataMember(Name = "created")]
		public DateTimeOffset Created { get; set; }

		/// <summary>
		///     Who updated the comment
		/// </summary>
		[DataMember(Name = "updateAuthor")]
		public User UpdateAuthor { get; set; }

		/// <summary>
		///     When was the comment updated
		/// </summary>
		[DataMember(Name = "updated")]
		public DateTimeOffset Updated { get; set; }

		/// <summary>
		///     Is a comment visible
		/// </summary>
		[DataMember(Name = "visibility")]
		public Visibility Visibility { get; set; }
	}
}