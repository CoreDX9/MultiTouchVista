﻿using System;
using System.ComponentModel;
using System.Configuration.Install;


namespace Multitouch.Service.Logic
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
		}
	}
}